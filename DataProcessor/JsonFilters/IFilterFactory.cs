using Common.Enums;

namespace DataProcessor.JsonFilters
{
    public  interface IFilterFactory
    {
        BaseJsonFilter GetFilter(FilterType type);
    }
}
