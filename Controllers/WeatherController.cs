using Microsoft.AspNetCore.Mvc;
using SantoshAzure.Models;
using System.Net;
using Newtonsoft.Json;

namespace SantoshAzure.Controllers
{
    public class WeatherController : Controller
    {
        public WeatherController() { }

        [HttpPost]
        public IActionResult Index()
        {
            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "9f456c6c01024dddbbf13b2a4a615168";

            //API path with CITY parameter and other parameters.  
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", "Paris", appId);
            ResultViewModel rslt = new ResultViewModel();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                RootObject weatherInfo = JsonConvert.DeserializeObject<RootObject>(json);

                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                rslt.Description = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);
                rslt.WeatherIcon = weatherInfo.weather[0].icon;

            }
            return PartialView("_WeatherView", rslt);
        }
    }
}
