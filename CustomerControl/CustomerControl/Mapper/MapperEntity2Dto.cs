using AutoMapper;
using CustomerControl.CrossCutting.Dto.Customer;
using CustomerControl.CrossCutting.Dto.User;
using CustomerControl.Domain;

namespace CustomerControl.Mapper
{
    public class MapperEntity2Dto : Profile
    {
        public MapperEntity2Dto()
        {
            CreateMap<Customer, CustomerDTO>();

            CreateMap<User, UserDTO>();
        }
    }
}