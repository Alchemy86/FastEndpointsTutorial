using AutoMapper;
using FastEndpointsTutorial.Models;
using FastEndpointsTutorial.Requests;
using FastEndpointsTutorial.Responses;

namespace FastEndpointsTutorial.Mappers;

public class WeatherForecastMapper : Mapper<WeatherForecaseRequest, WeatherForecastResponse, WeatherForecast>
{
    private readonly IMapper _mapper;

    public WeatherForecastMapper()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            //cfg.CreateMap<WeatherForecastResponse, WeatherForecast>();
            cfg.CreateMap<WeatherForecast, WeatherForecastResponse>();
        });
        _mapper = configuration.CreateMapper();
    }

    public override WeatherForecastResponse FromEntity(WeatherForecast r) => _mapper.Map<WeatherForecastResponse>(r);

}