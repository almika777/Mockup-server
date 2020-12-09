using Common.Enums;
using Common.Models;
using DataProcessor.Configuration;
using DataProcessor.JsonFilters;
using DataProcessor.Readers;
using DataProcessorTests.TestModels;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace DataProcessorTests
{
    class JsonArrayFilterTests : GlobalSetupTests
    {
        private FileModelReader _fileModelReader;
        private IJsonFilter _jsonFilter;
        private RouteModel _routeModel;

        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel
            {
                Route = "getObjects.arrayTest"
            };

            IApplicationConfig config = new ApplicationConfig
            {
                PathToRootFolder = @"C:\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File,
                FileName = "routes.json"
            };

            _fileModelReader = new FileModelReader(config, _filterFactory);
            _jsonFilter = new JsonArrayFilter();
        }

        [Test]
        public async Task FilterEqualAndMore()
        {
            //Arrange
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id>=2";

            //Act
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel).ToArray();
            var first = filteredToken.First().ToObject<SimpleTestModel>();
            var last = filteredToken.Last()?.ToObject<SimpleTestModel>();

            //Assert
            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(filteredToken.Length == 2);
            Assert.IsTrue(first.Id == 2);
            Assert.IsTrue(last.Id == 3);
        }

        [Test]
        public async Task FilterEqualAndLess()
        {
            //Arrange
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id<=2";

            //Act
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel).ToArray();
            var first = filteredToken.First().ToObject<SimpleTestModel>();
            var last = filteredToken.Last().ToObject<SimpleTestModel>();

            //Assert
            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(filteredToken.Length == 2);
            Assert.IsTrue(first.Id == 1);
            Assert.IsTrue(last.Id == 2);
        }

        [Test]
        public async Task FilterLess()
        {
            //Arrange
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id<3";

            //Act
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel).ToArray();
            var first = filteredToken.First().ToObject<SimpleTestModel>();
            var last = filteredToken.Last().ToObject<SimpleTestModel>();

            //Assert
            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(filteredToken.Length == 2);
            Assert.IsTrue(first.Id == 1);
            Assert.IsTrue(last.Id == 2);
        }

        [Test]
        public async Task FilterMore()
        {
            //Arrange
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id>1";

            //Act
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel).ToArray();
            var first = filteredToken.First().ToObject<SimpleTestModel>();
            var last = filteredToken.Last().ToObject<SimpleTestModel>();

            //Assert
            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(filteredToken.Length == 2);
            Assert.IsTrue(first.Id == 2);
            Assert.IsTrue(last.Id == 3);
        }
    }
}
