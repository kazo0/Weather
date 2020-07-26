using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Services
{
	public class OpenWeatherMapWeatherService : IWeatherService
	{
		public async Task<Forecast> GetForecast(double latitude, double longitude)
		{
			var language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

		}
	}
}
