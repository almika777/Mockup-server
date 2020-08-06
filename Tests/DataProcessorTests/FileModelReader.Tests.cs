using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Readers;
using DataProcessorTests.TestModels;
using MoveRouting.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessorTests
{
    public class Tests
    {
        private FileModelReader _fileModelReader;
        private RouteModel _routeModel;
        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel
            {
                RootRoute = "getObjects"
            };
            var config = new ApplicationConfig
            {
                PathToRootFolder = "C:\\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File
            };
            _fileModelReader = new FileModelReader(config);
        }

        [Test]
        public async Task ReadModelCollection()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            var deserializedModel = model.ToObject<Dictionary<long, SimpleTestModel>>();

            Assert.IsNotNull(model);
            Assert.IsNotNull(deserializedModel);
            Assert.IsNotNull(deserializedModel.Count(x => x.Value.Id > 0) > 0);
        }

        [Test]
        public async Task ReadModel()
        {
            _routeModel.Key = "1";
            var model = await _fileModelReader.ReadAsync(_routeModel);
            var deserializedModel = model.ToObject<SimpleTestModel>();

            Assert.IsNotNull(model);
            Assert.IsNotNull(deserializedModel);
            Assert.IsNotNull(deserializedModel.Id == 1);
        }
    }
}