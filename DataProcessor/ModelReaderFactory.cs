using System;
using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using DataProcessor.Readers;

namespace DataProcessor
{
    public class ModelReaderFactory
    {
        private readonly IApplicationConfig _config;
        private readonly JsonArrayFilter _jsonFilter;

        public ModelReaderFactory(IApplicationConfig config, JsonArrayFilter jsonFilter)
        {
            _config = config;
            _jsonFilter = jsonFilter;
        }

        public IModelReader GetModelReader()
        {
            var appModel = _config.ApplicationMode;
            return appModel switch
            {
                ApplicationMode.File => new FileModelReader(_config, _jsonFilter),
                ApplicationMode.Files => new FilesModelReader(_config),
                ApplicationMode.Dirrectory => new DirrectoryModelReader(_config),
                _ => throw new ArgumentOutOfRangeException(nameof(appModel), appModel, null)
            };
        }
    }
}
