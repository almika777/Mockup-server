using System.Diagnostics;
using System.Linq;
using AdditionalEntities.Enums;
using DataProcessor.Configuration;
using DataProcessor.Models;
using DataProcessor.Readers;
using NUnit.Framework;
using System.Threading.Tasks;
using DataProcessor.JsonFilters;
using DataProcessorTests.TestModels;

namespace DataProcessorTests
{
    class JsonArrayFilterTests
    {
        private FileModelReader _fileModelReader;
        private RouteModel _routeModel;
        private IJsonFilter _jsonFilter;

        [SetUp]
        public void Setup()
        {
            _routeModel = new RouteModel
            {
                Route = "getObjects.arrayTest"
            };

            var config = new ApplicationConfig
            {
                PathToRootFolder = @"C:\MockServerRootFolder",
                ApplicationMode = ApplicationMode.File
            };

            _fileModelReader = new FileModelReader(config);
            _jsonFilter = new JsonArrayFilter();
        }

        [Test]
        public async Task FilterEqualAndMore()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id>=2";
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel);
            var count = filteredToken.Count();
            var first = filteredToken.First?.ToObject<SimpleTestModel>();
            var last = filteredToken.Last?.ToObject<SimpleTestModel>();

            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(count == 2);
            Assert.IsTrue(first.Id == 2);
            Assert.IsTrue(last.Id == 3);
        }

        [Test]
        public async Task FilterEqualAndLess()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id<=2";
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel);
            var count = filteredToken.Count();
            var first = filteredToken.First?.ToObject<SimpleTestModel>();
            var last = filteredToken.Last?.ToObject<SimpleTestModel>();

            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(count == 2);
            Assert.IsTrue(first.Id == 1);
            Assert.IsTrue(last.Id == 2);
        }

        [Test]
        public async Task FilterLess()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id<3";
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel);
            var count = filteredToken.Count();
            var first = filteredToken.First?.ToObject<SimpleTestModel>();
            var last = filteredToken.Last?.ToObject<SimpleTestModel>();

            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(count == 2);
            Assert.IsTrue(first.Id == 1);
            Assert.IsTrue(last.Id == 2);
        }

        [Test]
        public async Task FilterMore()
        {
            var model = await _fileModelReader.ReadAsync(_routeModel);
            _routeModel.Query = "Id>1";
            var filteredToken = _jsonFilter.FilterToken(model, _routeModel);
            var count = filteredToken.Count();
            var first = filteredToken.First?.ToObject<SimpleTestModel>();
            var last = filteredToken.Last?.ToObject<SimpleTestModel>();

            Assert.IsNotNull(filteredToken);
            Assert.IsNotNull(first);
            Assert.IsTrue(count == 2);
            Assert.IsTrue(first.Id == 2);
            Assert.IsTrue(last.Id == 3);
        }
    }
}
