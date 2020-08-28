using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor.Models
{
    class QueryFilterModel
    {
        public string PropertyName { get; }
        public string ComparisonMark { get; }
        public string Value { get; }

        public QueryFilterModel(string propertyName, string comparisonMark, string value)
        {
            PropertyName = propertyName;
            ComparisonMark = comparisonMark;
            Value = value;
        }
    }
}
