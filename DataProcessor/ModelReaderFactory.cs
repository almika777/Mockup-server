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
                ApplicationMode.File => FileModelReader.Get(config),
                ApplicationMode.Files => FilesModelReader.Get(),
                ApplicationMode.Dirrectory => DirrectoryModelReader.Get(),
                _ => throw new ArgumentOutOfRangeException(nameof(appModel), appModel, null)
            };
        }
    }
}
