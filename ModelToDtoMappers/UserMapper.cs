using AutoMapper;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;

namespace Seat_broker_backend.ModelToDtoMappers
{
    public class UserMapper
    {
     public static MapperConfiguration UserMaps(){
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>();
                config.CreateMap<UserDto, User>();
            });
            return mappingConfig;
        }
    }
}
