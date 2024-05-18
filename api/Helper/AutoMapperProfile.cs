using api.DTOModels;
using api.Entities;
using AutoMapper;

namespace api.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<RegisterDTO, User>();
        }
    }
}
