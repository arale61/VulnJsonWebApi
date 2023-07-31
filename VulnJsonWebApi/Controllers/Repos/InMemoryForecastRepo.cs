namespace VulnJsonWebApi.Controllers
{
    public static class InMemoryForecastRepo
    {   
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static Dictionary<Guid, WeatherForecast> items = new Dictionary<Guid, WeatherForecast>();

        static InMemoryForecastRepo()
        {
            var tempItems = Enumerable.Range(1, 5).Select(index =>
            {
                return new WeatherForecast
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]

                };
            }).ToArray();

            foreach(var item in tempItems)
            {
                items.Add(item.Id, item);
            }
        }

        public static void AddItem(WeatherForecast weatherForecast)
        {
            if (items.ContainsKey(weatherForecast.Id))
            {
                items[weatherForecast.Id] = weatherForecast;
            }
            else
            {
                items.Add(weatherForecast.Id, weatherForecast);
            }
        }

        public static IEnumerable<WeatherForecast> GetAllForecasts() 
        {
            return items.Values.ToArray();
        }
    }
}