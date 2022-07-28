using Domain;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace API.Tasks
{
    public class WeatherMeasuringServiceOld : IHostedService
    {
        private readonly IConfiguration _configuration;
        private Timer? _timer;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherMeasuringServiceOld(IConfiguration configuration, IHttpClientFactory httpClientFactory, IServiceScopeFactory factory)
        {
            this._configuration = configuration;
            this._httpClientFactory = httpClientFactory;
            this._unitOfWork = factory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // frequency in seconds
            int frequency = _configuration.GetValue<int>("Weather:Frequency");

            TimeSpan interval = TimeSpan.FromSeconds(frequency);

            // Run first task instantly
            DateTime nextRunTime = DateTime.Now.AddSeconds(frequency);
            DateTime currentTime = DateTime.Now;
            TimeSpan firstInterval = nextRunTime.Subtract(currentTime);

            Action action = () =>
            {
                Task taskOne = Task.Delay(firstInterval);
                taskOne.Wait();

                RecordMeasurement(null);

                _timer = new Timer(RecordMeasurement, null, TimeSpan.Zero, interval);
            };

            Task.Run(action);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private async void RecordMeasurement(object state)
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

                Console.WriteLine(created.Region);
            }
        }
    }
}
