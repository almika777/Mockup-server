using AdditionalEntities.Enums;

namespace netcore_mock_server.Configuration
{
    public class ApplicationConfig : IApplicationConfig
    {
        public ApplicationMode ApplicationMode { get; set; }
        public string PathToRootFolder { get; set; }
    }
}
