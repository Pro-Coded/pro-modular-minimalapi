using System.Net.Http.Json;
using FluentAssertions;
using Modular.API.Features.Weather.Models;

namespace Modular.Tests;

public class WeatherIntegrationTests
{
    [Fact]
    public async Task GET_retrieves_weather_forecast()
    {
        var api = new ApiWebApplicationFactory();
        WeatherForecast[]? forecast = await api.CreateClient().GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
        _ = forecast.Should().HaveCount(5);
    }
}