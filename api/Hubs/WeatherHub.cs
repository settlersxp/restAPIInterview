using api.controllers;
using Microsoft.AspNetCore.SignalR;

namespace api.Hubs
{
    public class WeatherHub(WeatherLocationsController weatherForecastController) : Hub
    {
        private readonly WeatherLocationsController _weatherForecastController = weatherForecastController;

        //Receive a message from the client on the Hub called "ReceiveWeatherForecastsFor" and call the method "Get(locationId)" from the WeatherForecastController
        public async Task ReceiveWeatherForecastsFor(int locationId)
        {
            await Clients.All.SendAsync("ReceiveWeatherForecastsFor", await _weatherForecastController.Get(locationId));
        }


        // Receive a message from the client on the Hub called "requestWeatherForecastsAPI" and call the GET method "Get(locationId)" from the WeatherForecastController via HTTP call to https://localhost:5001/api/weatherforecast/{locationId}
        public async Task RequestWeatherForecastsAPI(int locationId)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:5001/api/weatherforecast/{locationId}");
            var content = await response.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveWeatherForecastsAPI", content);
        }

        // For authentication I would use the JWT token implementation from the UsersController based on https://learn.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-8.0
    }
}
