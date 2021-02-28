using Common.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataProcessor.JsonFilters
{
    public class JsonDictionaryFilter : BaseJsonFilter, IJsonFilter
    {
        public override JToken FilterToken(JToken source, RouteModel model)
        {
            var filterParams = GetFilterParams(model);

            foreach (var param in filterParams)
            {
                var token = GetToken(source, param);
                source = JToken.FromObject(token);

                if (!source.HasValues) break;
            }

            return source;
        }

        protected override IEnumerable<QueryFilterModel> GetFilterParams(RouteModel model)
            => model.Query.Split('&').Select(x =>
                {
                    var arguments = Regex.Split(x, Pattern);
                    if (arguments.Length != 3) throw new ArgumentException("Query pattern is not corrected");

                    return new QueryFilterModel(arguments[0], arguments[1], arguments[2]);
                });

        private JToken GetToken(JToken source, QueryFilterModel model)
        {
            if (model.ComparisonMark.Equals("=="))
                return source.Children()
                    .FirstOrDefault(x => x.Path.EndsWith(model.Value, true, null));

            var orderedTokens = model.ComparisonMark.Contains("<")
                ? source.OrderByDescending(x => x.Path).ToImmutableList()
                : source.OrderBy(x => x.Path).ToImmutableList();

            var tokenIndex = GetTokenIndex(model, orderedTokens);
            var result = GetItemsByMark(model, orderedTokens, tokenIndex);

            return JToken.FromObject(result);
        }

        private static int GetTokenIndex(QueryFilterModel model, ImmutableList<JToken> orderedTokens)
        {
            var item = orderedTokens.FirstOrDefault(x => x.Path.EndsWith(model.Value, true, null));
            return orderedTokens.IndexOf(item);
        }

        private static IEnumerable<JToken> GetItemsByMark(QueryFilterModel model,
            ImmutableList<JToken> orderedTokens, int ii)
        {
            var res = model.ComparisonMark switch
            {
                ">=" => orderedTokens.GetRange(ii, orderedTokens.Count - ii),
                "<=" => orderedTokens.GetRange(ii, orderedTokens.Count - ii),
                ">" => orderedTokens.GetRange(ii + 1, orderedTokens.Count - ii - 1),
                "<" => orderedTokens.GetRange(ii + 1, orderedTokens.Count - ii - 1),
                _ => Enumerable.Empty<JToken>()
            };

            return new JObject(res).ToObject<JToken>();
        }
    }
}
