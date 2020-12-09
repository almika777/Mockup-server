using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Common.Models;

namespace DataProcessor.JsonFilters
{
    public abstract class BaseJsonFilter : IJsonFilter
    {
        public abstract JToken FilterToken(JToken source, RouteModel model);
        protected abstract IEnumerable<QueryFilterModel> GetFilterParams(RouteModel model);
    }
}
