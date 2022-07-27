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
        public IEnumerable<StationViewModel> getAllStations()
        {
            IEnumerable<Station> stations = _unitOfWork.Station.GetAll();

           return _mapper.Map<IEnumerable<Station>, IEnumerable<StationViewModel>>(stations);
        }
    }
}
