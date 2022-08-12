using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eshop.Core.Contracts.Providers.WeatherForecast
{
    public partial interface IWeatherForecastProvider
    {
        /// <summary>
        /// List of fire weatherforcasts
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<ListWeatherForecastOutputModel>> List(ListWeatherForecastInputModel input);
    }
}
