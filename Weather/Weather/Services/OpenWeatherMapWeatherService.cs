using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Models;

namespace Weather.Services
{
	public class OpenWeatherMapWeatherService : IWeatherService
	{
		public async Task<Forecast> GetForecast(double latitude, double longitude)
		{
			var language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
			var uri =
				$"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={Secrets.ApiKey}";
			
			var httpClient = new HttpClient();
			var result = await httpClient.GetStringAsync(uri);

			var data = JsonConvert.DeserializeObject<WeatherData>(result);

			var forecast = new Forecast
			{
				City = data.City.Name,
				Items = data.List
					.Select(x => new ForecastItem
					{
						DateTime = ToDateTime(x.Dt),
						Temperature = x.Main.Temp,
						WindSpeed = x.Wind.Speed,
						Description = x.Weather.First().Description,
						Icon = $"http://openweathermap.org/img/w/{x.Weather.First().Icon}.png"
					})
					.ToList()
			};

			return forecast;
		}

		private DateTime ToDateTime(double unixTimeStamp)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0,
				DateTimeKind.Utc);
			dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dateTime;
		}
	}
}
