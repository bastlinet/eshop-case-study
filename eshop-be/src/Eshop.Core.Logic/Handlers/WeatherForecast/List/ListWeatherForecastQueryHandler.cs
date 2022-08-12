using AutoMapper;
using Eshop.Core.Contracts.Handlers.WeatherForecast.List;
using Eshop.Core.Contracts.Providers.WeatherForecast;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Core.Logic.Handlers.WeatherForecast.List
{
    public class ListWeatherForecastQueryHandler : IRequestHandler<ListWeatherForecastQuery, ListWeatherForecastModel>
    {
        private readonly IWeatherForecastProvider weatherForecastProvider;
        private readonly IMapper mapper;

        public ListWeatherForecastQueryHandler(IWeatherForecastProvider weatherForecastProvider, IMapper mapper)
        {
            this.weatherForecastProvider = weatherForecastProvider;
            this.mapper = mapper;
        }

        public async Task<ListWeatherForecastModel> Handle(ListWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var result = new ListWeatherForecastModel();

            var weathers = await weatherForecastProvider.List(mapper.Map<ListWeatherForecastInputModel>(request));
            result.Items = weathers.Select(x => mapper.Map<ListWeatherForecastItemModel>(x));

            return await Task.FromResult(result);
        }
    }
}
