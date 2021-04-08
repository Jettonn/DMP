using DMP.Dtos;
using DMP.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMP.Enrichers
{
    public static class GeoLocation
    {
        public async static Task GeoLocationInfo(EventDto eventDto, Event eventData)
        {
            var client = new RestClient($"http://ip.gjirafa.tech/" + eventDto.IpAddress);
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            var jObject = JObject.Parse(response.Content);
            eventData.Country = jObject.GetValue("Country").ToString();
            eventData.Asn = (int)jObject.GetValue("Asn");
            eventData.Aso = jObject.GetValue("Aso").ToString();
        }
    }
}
