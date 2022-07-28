using Domain;
using Domain.Interfaces;
using System.Text.Json;

namespace API.Tasks
{
    public class WeatherMeasuringService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private PeriodicTimer? _timer;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherMeasuringService(IConfiguration configuration, IHttpClientFactory httpClientFactory, IServiceScopeFactory factory)
        {
            this._configuration = configuration;
            this._httpClientFactory = httpClientFactory;
            this._unitOfWork = factory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // frequency in seconds
            int frequency = _configuration.GetValue<int>("Weather:Frequency");

            _timer = new PeriodicTimer(TimeSpan.FromSeconds(frequency));

            while (await _timer.WaitForNextTickAsync(stoppingToken))
            {
                RecordMeasurement();
            }
        }

        private async void RecordMeasurement()
        {
            string apiUrl = _configuration.GetValue<string>("Weather:Api");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            request.Headers.Add("Accept", "application/json");

            HttpClient client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            var contents = await response.Content.ReadAsStringAsync();

            var deserialized = JsonSerializer.Deserialize<JsonElement>(contents);

            JsonElement actual = deserialized.GetProperty("actual");
            JsonElement measurements = actual.GetProperty("stationmeasurements");

            for (int i = 0; i < measurements.GetArrayLength(); i++)
            {
                int stationId = measurements[i].GetProperty("stationid").GetInt32();
                string name = measurements[i].GetProperty("stationname").GetString();
                string region = measurements[i].GetProperty("regio").ToString();

                Station station = new Station(stationId, name, region);

                Station created = _unitOfWork.Station.FindOrCreate(station);
            }

            _unitOfWork.Save();
        }
    }
}
