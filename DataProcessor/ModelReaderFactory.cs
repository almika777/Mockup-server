using System;
using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Readers;

namespace DataProcessor
{
    public class ModelReaderFactory
    {
        public IModelReader GetModelReader(IApplicationConfig config)
        {
            var appModel = config.ApplicationMode;
            return appModel switch
            {
                ApplicationMode.File => new FileModelReader(config),
                ApplicationMode.Files => new FilesModelReader(config),
                ApplicationMode.Dirrectory => new DirrectoryModelReader(config),
                _ => throw new ArgumentOutOfRangeException(nameof(appModel), appModel, null)
            };
        }
    }
}
