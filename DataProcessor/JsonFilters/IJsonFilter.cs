using DataProcessor.Models;
using Newtonsoft.Json.Linq;

namespace DataProcessor.JsonFilters
{
    public interface IJsonFilter
    {
        JToken FilterToken(JToken source, RouteModel model);
    }
}
