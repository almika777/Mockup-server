namespace Common.Models
{
    public class QueryFilterModel
    {
        private string _comparisonMark;
        public string PropertyName { get; }

        public string ComparisonMark
        {
            get => _comparisonMark;
            set => _comparisonMark = value == "=" ? "==" : value;
        }

        public string Value { get; }

        public QueryFilterModel(string propertyName, string comparisonMark, string value)
        {
            PropertyName = propertyName;
            ComparisonMark = comparisonMark;
            Value = value;
        }
    }
}
