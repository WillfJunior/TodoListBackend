using AutoMapper;
using Domain.Entities;
using Domain.Entities.Models.DTO;

namespace Application.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Todos,TodosDTO>().ReverseMap();
        }
    }
}
