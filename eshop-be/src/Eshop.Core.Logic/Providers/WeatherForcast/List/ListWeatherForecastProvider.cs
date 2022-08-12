using Eshop.Core.Contracts.Providers.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Core.Logic.Providers.WeatherForecast
{
    public partial class WeatherForecastProvider : IWeatherForecastProvider
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public async Task<IEnumerable<ListWeatherForecastOutputModel>> List(ListWeatherForecastInputModel input)
        {
            var list = Enumerable.Range(1, 5).Select(index => new ListWeatherForecastOutputModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = new Random().Next(-20, 55),
                Summary = Summaries[new Random().Next(Summaries.Length)]
            });

            return await Task.FromResult(list);
        }
    }
}
