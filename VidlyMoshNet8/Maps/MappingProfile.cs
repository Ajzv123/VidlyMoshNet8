using AutoMapper;
using VidlyMoshNet8.DTO;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomerDTO>();
            CreateMap<CustomerDTO, Customers>();
        }
    }
}
