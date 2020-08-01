using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using MoveRouting.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DataProcessorTests
{
    public class Tests
    {
        private FileModelReader _fileModelReader;

        [SetUp]
        public void Setup()
        {
            var config = new ApplicationConfig
            {
                PathToRootFolder = "C:\\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File
            };
            _fileModelReader = new FileModelReader(config);
        }

        [Test]
        public async Task ReadAllModels()
        {
            var routeModel = new RouteModel
            {
                RootRoute = "getObjects"
            };
            var model = await _fileModelReader.ReadAsync(routeModel);
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Count == 2);
        }
    }
}