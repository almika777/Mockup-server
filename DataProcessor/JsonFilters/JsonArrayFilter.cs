using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common.Models;

namespace DataProcessor.JsonFilters
{
    public class JsonArrayFilter : BaseJsonFilter
    {
        private const string Pattern = "(<=|>=|<|>|=)";

        public override JToken FilterToken(JToken source, RouteModel model)
        {
            var filterParams = GetFilterParams(model);

            foreach (var param in filterParams)
            {
                var filter = BuildEqualsFilter(param);
                var tokens = source.SelectTokens(filter);
                source = JToken.FromObject(tokens);
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

        private static string BuildEqualsFilter(QueryFilterModel model) =>
            $@"[?(@.{model.PropertyName.ToLower()} {model.ComparisonMark} {model.Value})]";
    }
}
