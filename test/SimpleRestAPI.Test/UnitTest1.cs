using System;
using Xunit;
using SimpleRestAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System.Text;
using System.Collections;

namespace SimpleRestAPI.Test
{
    public class UnitTest1
    {
        ILogger<WeatherForecastController> myLogger = new Logger<WeatherForecastController>(new NullLoggerFactory());
        WeatherForecastController controller = new WeatherForecastController(new Logger<WeatherForecastController>(new NullLoggerFactory()));

        [Fact]
        public void GetReturnsTodayWeather()
        {
            String todayDate = new String("31-07-2022");
            
            var returnValue = controller.Get();
            
            WeatherForecast w = new WeatherForecast();

            using (System.Collections.Generic.IEnumerator<WeatherForecast> enumer = returnValue.GetEnumerator())
            {
                if (enumer.MoveNext()) w = enumer.Current;
            }
            
            Assert.Equal(w.Date.ToString().Substring(0,10), todayDate);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
