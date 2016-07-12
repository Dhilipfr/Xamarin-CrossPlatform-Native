using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace App2
{
   
    public class Data
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }

   
    public class People
    {        
        public RootObject GetWeather() {
            string appId = "0f17ae51a8691b2133462e309cea8db6";
            var lat = "10.80289";
            var lon = "78.698753";
            string url = string.Format("http://api.openweathermap.org/data/2.5/find?lat={0}&lon={1}&cnt=10&AppId={2}", lat, lon , appId);

            var client = new HttpClient();
            var json = client.GetStringAsync(url).Result;

            var items = JsonConvert.DeserializeObject<RootObject>(json);            
            //WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
            //foreach (var item in items)
            //{
            //    WatherInfo.Add(item);
            //}
            return items;
        }
        public List<Data> GetPeople()
        {
            var people = new List<Data>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Data data = new Data();
                    data.Name = "TestName" + i;
                    data.Age = "TestAge" + i;
                    data.Address = "TestAddress" + i;

                    people.Add(data);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return people;
        }
    }
}

