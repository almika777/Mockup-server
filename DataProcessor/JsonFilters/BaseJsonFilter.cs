using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataProcessor.JsonFilters
{
    public class BaseJsonFilter
    {
        private const string Pattern = "(<=|>=|<|>|=)";

        protected IEnumerable<QueryFilterModel> GetFilterParams(RouteModel model)
        {
            return model.Query.Split('&').Select(x =>
            {
                var splitted = Regex.Split(x, Pattern);
                if (splitted.Length != 3) throw new ArgumentException("Query pattern is not corrected");

                return new QueryFilterModel(splitted[0], splitted[1], splitted[2]);
            });
        }
    }
}
