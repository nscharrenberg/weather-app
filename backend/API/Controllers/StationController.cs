using API.Queries;
using API.ViewModels;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StationViewModel>> GetAllStations()
        {
            IEnumerable<Station> stations = _unitOfWork.Station.GetAll();

           return Ok(_mapper.Map<IEnumerable<Station>, IEnumerable<StationViewModel>>(stations));
        }

        [HttpGet("{stationId}")]
        public ActionResult<StationViewModel> GetStationByStationId(int stationId, [FromQuery] GetStationQueryParameters parameters)
        {
            Station? found = _unitOfWork.Station.GetByStationId(stationId);

            if (found == null)
            {
                return NotFound();
            }

            DateTime? startTimestamp = parameters.Start;

            if (startTimestamp.HasValue)
            {
                DateTime? endTimestamp = parameters.End;

                if (!endTimestamp.HasValue)
                {
                    endTimestamp = startTimestamp.Value.AddDays(7);
                }

                IEnumerable<Measurement> measurements = _unitOfWork.Measurement.GetByStationAndTimestampRange(found, startTimestamp.Value, endTimestamp.Value);

                found.Measurements = (List<Measurement>)measurements;
            }

            return Ok(_mapper.Map<Station, StationViewModel>(found));
        }
    }
}
