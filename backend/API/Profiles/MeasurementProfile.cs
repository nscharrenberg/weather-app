using API.ViewModels;
using AutoMapper;
using Domain;

namespace API.Profiles
{
    public class MeasurementProfile : Profile
    {
        public MeasurementProfile()
        {
            CreateMap<Measurement, MeasurementViewModel>();
        }
    }
}
