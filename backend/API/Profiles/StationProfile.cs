using API.ViewModels;
using AutoMapper;
using Domain;

namespace API.Profiles
{
    public class StationProfile : Profile
    {
        public StationProfile()
        {
            CreateMap<Station, StationViewModel>();
        }
    }
}
