using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace MyIP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var location = GetGeoLocation();

                Console.ForegroundColor = ConsoleColor.White;

                var json = JsonConvert.SerializeObject(location, Formatting.Indented);
                Console.WriteLine(json);

                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ResetColor();
            }
        }

        private static GeoLocation GetGeoLocation()
        {
            var client = new RestClient(new Uri("http://freegeoip.net/json/"));
            var request = new RestRequest(Method.GET);
            var response = client.Execute<GeoLocation>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            return null;
        }
    }

    internal class GeoLocation
    {
        public string Ip { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string MetroCode { get; set; }
        public string AreaCode { get; set; }
    }
}
