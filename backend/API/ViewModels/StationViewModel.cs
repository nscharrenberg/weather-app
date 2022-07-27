namespace API.ViewModels
{
    public class StationViewModel
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public List<MeasurementViewModel> Measurements { get; set; }
    }
}
