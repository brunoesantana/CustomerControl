using AutoMapper;
using CustomerControl.CrossCutting.Dto.Customer;
using CustomerControl.CrossCutting.Dto.User;
using CustomerControl.CrossCutting.Helper;
using CustomerControl.Domain;

namespace CustomerControl.Mapper
{
    public class MapperDto2Entity : Profile
    {
        public MapperDto2Entity()
        {
            CreateMap<CustomerInsertDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();

            CreateMap<UserInsertDTO, User>()
                .ForMember(to => to.Password, map => map.MapFrom(from => EncryptHelper.EncryptPassword(from.Password)));

            CreateMap<UserUpdateDTO, User>();
        }
    }
}