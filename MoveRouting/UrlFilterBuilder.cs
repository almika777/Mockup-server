using System.Collections.Generic;

namespace MoveRouting
{
    public class UrlFilterBuilder
    {
        private readonly string _filter;
        private UrlFilterBuilder _instance;

        private UrlFilterBuilder(ModelReaderFactory)
        {
            _filter = filter;
        }

        public UrlFilterBuilder Instance(string filter)
            => _instance ??= new UrlFilterBuilder(filter);


        public IDictionary<string, T> Build<T>()
        {
            return null;
        }
    }
}
