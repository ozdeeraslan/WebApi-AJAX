using Microsoft.AspNetCore.Mvc;

namespace WebApiGorevler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly Random random = new Random();
        private readonly string[] Bloklar = { "A", "B", "C", "D", "E" };

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")] // name: metodun adini verir. name'i vermezsek rotaya ekler (url'de gözükür)
        // [HttpGet(Name ="GetWeatherForecast")] 
        public IEnumerable<WeatherForecast> Get()
        { 
            // 2.yol
            IEnumerable<WeatherForecast> list = new List<WeatherForecast>();
            for (int i = 0; i <=5; i++)
            {
                WeatherForecast weatherForecast = new WeatherForecast();
                weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));
                weatherForecast.TemperatureC = Random.Shared.Next(-20, 55);
                weatherForecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
                ((List<WeatherForecast>)list).Add(weatherForecast);
            }
            return list;

            // 1.yol
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpGet("Karsilama")] 
        public string GetKarsilama()
        {
            return "Merhaba";
        }


        // Görev3
        [HttpGet("ApartmanGideri")]
        public IEnumerable<string> GetApartmanGideri()
        {
            List<string> apartmanGideri = new List<string>();

            foreach (var blok in Bloklar)
            {
                for (int i = 1; i <= 200; i++)
                {
                    int gider = random.Next(1500, 2501);
                    string apartmanSayisi = $"{blok}-{i}-{gider}";
                    apartmanGideri.Add(apartmanSayisi);
                }
            }

            return apartmanGideri;
        }

        // Görev4
        [HttpGet("AsalMi")]
        public bool GetAsal(int sayi)
        {
            if (sayi < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
