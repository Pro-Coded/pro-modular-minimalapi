using Modular.API.Features.Weather.Models;

namespace Modular.API.Features.Weather;
public interface IWeatherService
{
    WeatherForecast[] GetWeather();
}