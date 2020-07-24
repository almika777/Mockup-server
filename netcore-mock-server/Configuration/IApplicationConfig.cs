namespace netcore_mock_server.Configuration
{
    public interface IApplicationConfig
    {
        ApplicationMode ApplicationMode { get; set; }
        string PathToRootFolder { get; set; }
    }
}
