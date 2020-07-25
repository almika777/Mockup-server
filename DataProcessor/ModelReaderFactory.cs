using System;
using AdditionalEntities.Enums;
using DataProcessor.Readers;

namespace DataProcessor
{
    public class ModelReaderFactory
    {
        public static IModelReader GetModelReader(ApplicationMode appMode)
        {
            return appMode switch
            {
                ApplicationMode.File => FileModelReader.Get(),
                ApplicationMode.Files => FilesModelReader.Get(),
                ApplicationMode.Dirrectory => DirrectoryModelReader.Get(),
                _ => throw new ArgumentOutOfRangeException(nameof(appMode), appMode, null)
            };
        }
    }
}
