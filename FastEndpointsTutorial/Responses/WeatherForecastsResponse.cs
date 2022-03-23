namespace FastEndpointsTutorial.Responses;

public class WeatherForecastsResponse
{
    public IEnumerable<WeatherForecastResponse> Forecasts { get; init; }
}