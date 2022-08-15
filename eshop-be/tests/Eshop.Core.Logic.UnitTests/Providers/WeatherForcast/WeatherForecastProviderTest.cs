using Eshop.Core.Contracts.Providers.WeatherForecast;
using Eshop.Core.Logic.Providers.WeatherForecast;

namespace Eshop.Core.Logic.UnitTests.Providers.WeatherForecast
{
    public partial class WeatherForecastProviderTest
    {
        private readonly IWeatherForecastProvider sut;

        public WeatherForecastProviderTest()
        {
            sut = new WeatherForecastProvider();
        }
    }
}
