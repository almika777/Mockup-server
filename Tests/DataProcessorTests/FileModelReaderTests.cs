using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Models;
using DataProcessor.Readers;
using DataProcessorTests.TestModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DataProcessorTests
{
    public class FileModelReaderTests
    {
        private FileModelReader _fileModelReader;
        private RouteModel _routeModel;

        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel
            {
                Route = "getObjects"
            };
            var config = new ApplicationConfig
            {
                PathToRootFolder = @"C:\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File
            };
            _fileModelReader = new FileModelReader(config);
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