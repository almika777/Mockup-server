using DataProcessor.Readers;
using DataProcessorTests.TestModels;
using NUnit.Framework;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;

namespace DataProcessorTests
{
    public class FileModelReaderTests : GlobalSetupTests
    {
        private FileModelReader _fileModelReader;
        private RouteModel _routeModel;
        private ApplicationConfig _config;

        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel
            {
                Route = "getObjects"
            };

            _config = new ApplicationConfig
            {
                PathToRootFolder = @"C:\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File
            };

            _filterFactory = new FilterFactory();
            _fileModelReader = new FileModelReader(_config, _filterFactory);
        }

        [Test]
        public async Task ReadModelCollection()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            var deserializedModel = model.ToObject< SimpleTestModel>();

            Assert.IsNotNull(model);
            Assert.IsNotNull(deserializedModel);
        }
    }
}