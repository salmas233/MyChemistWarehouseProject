using AutoMapper;
using MCWH.CompanyManager.Data;

namespace MCWH.CompanyManager.API.Models
{
    public class ModelMapper
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => 
            cfg.CreateMap<CompanyViewModel, Company>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.companyName))
            .ForMember(dest => dest.YearEstablished, opt => opt.MapFrom(src => src.yearEstablished))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.phone))
            .ReverseMap());
        }
    }
}