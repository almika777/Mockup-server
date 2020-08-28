using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using DataProcessorTests.TestModels;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataProcessor.Models;

namespace DataProcessorTests
{
    public class Tests
    {
        private FileModelReader _fileModelReader;
        private RouteModel _routeModel;

        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel("getObjects.1");
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