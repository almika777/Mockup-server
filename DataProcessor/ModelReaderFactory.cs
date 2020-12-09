using System;
using Common.Enums;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using DataProcessor.Readers;

namespace DataProcessor
{
    public class ModelReaderFactory
    {
        private readonly IApplicationConfig _config;
        private readonly FilterFactory _filterFactory;

        public ModelReaderFactory(IApplicationConfig config, FilterFactory filterFactory)
        {
            _config = config;
            _filterFactory = filterFactory;
        }

        public IModelReader GetModelReader()
        {
            var appModel = _config.ApplicationMode;
            return appModel switch
            {
                ApplicationMode.File => new FileModelReader(_config, _filterFactory),
                ApplicationMode.Files => new FilesModelReader(_config),
                ApplicationMode.Directory => new DirrectoryModelReader(_config),
                _ => throw new ArgumentOutOfRangeException(nameof(appModel), appModel, null)
            };
        }
    }
}
