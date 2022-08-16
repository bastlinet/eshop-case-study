using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eshop.Core.Contracts.Providers.WeatherForecast
{
    public partial interface IWeatherForecastProvider
    {
        /// <summary>
        /// List of fire weatherforcasts
        /// </summary>
        /// <param name="input">filter model for forecasting</param>
        /// <returns>enumerable of forecasts</returns>
        Task<IEnumerable<ListWeatherForecastOutputModel>> List(ListWeatherForecastInputModel input);
    }
}
