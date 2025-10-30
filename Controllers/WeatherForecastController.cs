
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeatherTracker.Models;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly WeatherApiConfig _config;

    public WeatherController(HttpClient httpClient, IOptions<WeatherApiConfig> config)
    {
        _httpClient = httpClient;
        _config = config.Value;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var url = $"{_config.BaseUrl}?q={city}&appid={_config.ApiKey}&units=metric";

        var response = await _httpClient.GetStringAsync(url);
        return Content(response, "application/json");
    }
}
