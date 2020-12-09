using Common.Enums;
using System;

namespace DataProcessor.JsonFilters
{
    public class FilterFactory : IFilterFactory
    {
        private readonly JsonArrayFilter _jsonArrayFilter;
        private readonly JsonDictionaryFilter _jsonDictionaryFilter;

        public FilterFactory()
        {
            _jsonArrayFilter = new JsonArrayFilter();
            _jsonDictionaryFilter = new JsonDictionaryFilter();
        }

        public BaseJsonFilter GetFilter(FilterType type) => type switch
        {
            FilterType.Array => _jsonArrayFilter,
            FilterType.Dictionary => _jsonDictionaryFilter,
            _ => throw new TypeAccessException()
        };
    }
}
