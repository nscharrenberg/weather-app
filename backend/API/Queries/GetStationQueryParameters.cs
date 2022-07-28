using System.ComponentModel.DataAnnotations;

namespace API.Queries
{
    public class GetStationQueryParameters
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
