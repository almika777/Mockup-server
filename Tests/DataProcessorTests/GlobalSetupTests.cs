using DataProcessor.JsonFilters;

namespace DataProcessorTests
{
    public abstract class GlobalSetupTests
    {
        protected FilterFactory _filterFactory;

        protected GlobalSetupTests()
        {
            _filterFactory = new FilterFactory();
        }
    }
}
