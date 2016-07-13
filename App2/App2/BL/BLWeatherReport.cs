using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2.BL
{
    public class BLWeatherReport
    {
        public string Lattitude { get; set; }
        public string Longitude { get; set; }
        public string ApiId { get; } = "Get API Id from openweathermap";
        public string DistrictUrl { get; set; }
        public RootObject WeatherList { get; set; }

        public BLWeatherReport(string lattitude, string longitude)
        {
            this.Lattitude = lattitude;
            this.Longitude = longitude;
            DistrictUrl = string.Format("http://api.openweathermap.org/data/2.5/find?lat={0}&lon={1}&cnt=10&AppId={2}", Lattitude, Longitude, ApiId);
        }
        public async Task GetWeather()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync(DistrictUrl);
            WeatherList = JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
}
