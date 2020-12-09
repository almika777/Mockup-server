using Common.Enums;

namespace DataProcessor.Configuration
{
    public class ApplicationConfig : IApplicationConfig
    {
        public ApplicationMode ApplicationMode { get; set; }
        public string PathToRootFolder { get; set; }
        public string FileName { get; set; }
    }
}
