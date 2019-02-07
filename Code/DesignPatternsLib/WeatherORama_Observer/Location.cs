using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace DesignPatternsLib.WeatherORama_Observer
{
    public class Location
    {
        private string m_json = String.Empty;
        public string StreetNumber { get; set; } = String.Empty;
        public string StreetName { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public string County { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string StateAbbreviation { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string CountryAbbreviation { get; set; } = String.Empty;
        public string PostalCode { get; set; } = String.Empty;
        public string PostalCodeSuffix { get; set; } = String.Empty;
        public string Latitude { get; set; } = String.Empty;
        public string Longitude { get; set; } = String.Empty;
        public string PlaceID { get; set; } = String.Empty;
        public string FormattedAddress { get; set; } = String.Empty;

        public Location(string streetNumber = "", string streetName = "", string city = "", string state = "", string postalCode = "")
        {
            StreetNumber = streetNumber;
            StreetName = streetName.Replace(' ', '+');
            City = city.Replace(' ', '+');
            State = state.Replace(' ', '+');
            PostalCode = postalCode;

            if (!String.IsNullOrEmpty(StreetName))
                City += "+";

            if (!String.IsNullOrEmpty(City))
                City += "+";

            if (!String.IsNullOrEmpty(State))
                State += "+";

            string apiKey = API.Keys.GoogleGeocoding;
            string baseUrl = @"https://maps.googleapis.com/maps/api/geocode/json";
            string urlParameters = String.Format(
                "?address={0}{1}{2}{3}{4}&key={5}",
                StreetNumber,
                StreetName,
                City,
                State,
                PostalCode,
                apiKey
            );

            Console.WriteLine(baseUrl + urlParameters);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;

                if(response.IsSuccessStatusCode)
                {
                    m_json = response.Content.ReadAsStringAsync().Result;
                    ParseJson();
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private void ParseJson()
        {
            dynamic jsonData = JsonConvert.DeserializeObject(m_json);

            PlaceID = jsonData.results[0].place_id;
            FormattedAddress = jsonData.results[0].formatted_address;
            Latitude = jsonData.results[0].geometry.location.lat;
            Longitude = jsonData.results[0].geometry.location.lng;

            foreach (var component in jsonData.results[0].address_components)
            {
                switch ((string)component.types[0])
                {
                    case ("street_number"):
                        StreetNumber = component.long_name;
                        break;
                    case ("route"):
                        StreetName = component.long_name;
                        break;
                    case ("locality"):
                        City = component.long_name;
                        break;
                    case ("administrative_area_level_2"):
                        County = component.long_name;
                        break;
                    case ("administrative_area_level_1"):
                        State = component.long_name;
                        StateAbbreviation = component.short_name;
                        break;
                    case ("country"):
                        Country = component.long_name;
                        CountryAbbreviation = component.short_name;
                        break;
                    case ("postal_code"):
                        PostalCode = component.long_name;
                        break;
                    case ("postal_code_suffix"):
                        PostalCodeSuffix = component.long_name;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
