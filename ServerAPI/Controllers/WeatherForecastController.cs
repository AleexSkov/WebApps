using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ServerAPI.Controllers;

[ApiController]
[Route("vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private static readonly string[] Locations = new[]
    {
        "Århus", "Esbjerg", "Fredericia", "Middelfart", "Vejle", "København", "Harboøre"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route(template:"random")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Location = Locations[Random.Shared.Next(Locations.Length)],
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]

            })
            .ToArray();
    }
    
    [HttpGet]
    [Route(template:"{n:int}")]
    public IEnumerable<WeatherForecast> Get1(int n)
    {
        return Enumerable.Range(1, n).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Location = Locations[Random.Shared.Next(Locations.Length)],
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}