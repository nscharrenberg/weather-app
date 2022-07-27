namespace API.ViewModels
{
    public class MeasurementViewModel
    {
        public int Id { get; set; }
        public int StationId { get; set; }

        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double FeelTemperature { get; set; }
        public double GroundTemperature { get; set; }
        public string WindDirection { get; set; }
        public int SunPower { get; set; }
        public double RainFallLastDay { get; set; }
    }
}
