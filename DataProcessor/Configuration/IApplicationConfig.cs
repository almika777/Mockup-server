using AdditionalEntities.Enums;

namespace DataProcessor.Configuration
{
    public interface IApplicationConfig
    {
        ApplicationMode ApplicationMode { get; set; }
        string PathToRootFolder { get; set; }
    }
}
