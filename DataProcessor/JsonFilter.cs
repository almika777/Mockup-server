using System;
using DataProcessor.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataProcessor
{
    public class JsonFilter//TODO: tests on many scenaries
    {
        private const string Pattern = "(<=|>=|<|>|=)";

        public JToken FilterToken(JToken source, RouteModel model)
        {
            var filterParams = GetFilterParams(model);
            var objectRootName = source.First?.ToObject<JProperty>().Name;

            Parallel.ForEach(filterParams, param =>
            {
                var filter = BuildEqualsFilter(objectRootName, param);
                var tokens = source.SelectTokens(filter);
                source = JToken.FromObject(tokens);
            });

            return source;
        }

        private IEnumerable<QueryFilterModel> GetFilterParams(RouteModel model)
        {
            return model.Query.Split('&').Select(x =>
            {
                var splitted = Regex.Split(x, Pattern);
                if (splitted.Length != 3) throw new ArgumentException("Query pattern is not corrected");

                return new QueryFilterModel(splitted[0], splitted[1], splitted[2]);
            });
        }

        private static string BuildEqualsFilter(string objectRootName, QueryFilterModel model) => 
            $@"{objectRootName}[?(@{model.PropertyName} {model.ComparisonMark} {model.Value})]";
        
    }
}
