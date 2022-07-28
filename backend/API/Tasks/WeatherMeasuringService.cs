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
                JsonElement stationData = measurements[i];

                int stationId = stationData.GetProperty("stationid").GetInt32();
                string name = stationData.GetProperty("stationname").GetString();
                string region = stationData.GetProperty("regio").ToString();

                Station station = new Station(stationId, name, region);

                Station created = _unitOfWork.Station.FindOrCreate(station);
                
                DateTime timestamp = DateTime.Now;
                double temperature = 0;
                double feelTemperature = 0;
                double groundTemperature = 0;
                string windDirection = "";
                int sunPower = 0;
                double rainFallLastDay = 0;

                if (stationData.TryGetProperty("timestamp", out JsonElement timestampElement))
                {
                    timestampElement.TryGetDateTime(out DateTime timestampOut);

                    timestamp = timestampOut;
                }

                if (stationData.TryGetProperty("temperature", out JsonElement temperatureElement))
                {
                    temperatureElement.TryGetDouble(out double temperatureOut);

                    temperature = temperatureOut;
                }

                if (stationData.TryGetProperty("feeltemperature", out JsonElement feelTemperatureElement))
                {
                    feelTemperatureElement.TryGetDouble(out double feelTemperatureOut);

                    feelTemperature = feelTemperatureOut;
                }

                if (stationData.TryGetProperty("groundtemperature", out JsonElement groundTemperatureElement))
                {
                    groundTemperatureElement.TryGetDouble(out double groundTemperatureOut);

                    groundTemperature = groundTemperatureOut;
                }

                if (stationData.TryGetProperty("winddirection", out JsonElement windDirectionElement))
                {
                    windDirection = windDirectionElement.GetString();
                }

                if (stationData.TryGetProperty("sunpower", out JsonElement sunPowerElement))
                {
                    sunPowerElement.TryGetDouble(out double sunPowerOut);

                    sunPower = Convert.ToInt32(sunPowerOut);
                }

                if (stationData.TryGetProperty("rainFallLast24Hour", out JsonElement rainFaillLasstDayElement))
                {
                    rainFaillLasstDayElement.TryGetDouble(out double rainFaillLasstDayOut);

                    rainFallLastDay = rainFaillLasstDayOut;
                }


                Measurement measurement = new Measurement(created, timestamp, temperature, feelTemperature, groundTemperature, windDirection, sunPower, rainFallLastDay);

                _unitOfWork.Measurement.Add(measurement);
            }

            _unitOfWork.Save();

            Console.WriteLine($"Recorded at {DateTime.Now}");
        }
    }
}
