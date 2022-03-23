using AutoMapper;
using FastEndpointsTutorial.Mappers;
using FastEndpointsTutorial.Models;
using FastEndpointsTutorial.Requests;
using FastEndpointsTutorial.Responses;

namespace FastEndpointsTutorial.Endpoints;

public class WeatherForecastEndpoint : Endpoint<WeatherForecaseRequest, WeatherForecastsResponse, WeatherForecastMapper>
{
    private readonly IMapper _mapper;

    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public override void Configure()
    {
        Verbs(Http.GET);
        Routes("weather/{days}");
        AllowAnonymous();
        Description(x => x.Produces<WeatherForecastResponse>(200, "application/json"));
    }

    public WeatherForecastEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public override async Task HandleAsync(WeatherForecaseRequest req, CancellationToken ct)
    {
        Logger.LogDebug("Retrieving weather for {Days} days", req.Days);
        

        var rng = new Random();
        var forecasts  = Enumerable.Range(1, req.Days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        
        var response = new WeatherForecastsResponse
        {
            Forecasts = forecasts.Select(x => Map.FromEntity(x))
        };

        await SendAsync(response, cancellation: ct);
    }
}