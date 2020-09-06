using DataProcessor.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DataProcessor.JsonFilters
{
    public class JsonArrayFilter : BaseJsonFilter, IJsonFilter
    {

        public JToken FilterToken(JToken source, RouteModel model)
        {
            var filterParams = GetFilterParams(model);

            Parallel.ForEach(filterParams, param =>
            {
                var filter = BuildEqualsFilter(param);
                var tokens = source.SelectTokens(filter);
                source = JToken.FromObject(tokens);
            });

            return source;
        }

        private static string BuildEqualsFilter(QueryFilterModel model) =>
            $@"[?(@{model.PropertyName}{model.ComparisonMark}{model.Value})]";
    }
}
