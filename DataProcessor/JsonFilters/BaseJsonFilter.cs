using Common.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace DataProcessor.JsonFilters
{
    public abstract class BaseJsonFilter
    {
        protected const string Pattern = "(<=|>=|<|>|=)";

        public abstract JToken FilterToken(JToken source, RouteModel model);
        protected abstract IEnumerable<QueryFilterModel> GetFilterParams(RouteModel model);
    }
}
