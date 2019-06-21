using AutoMapper;
using Model.DTO;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dist => dist.UserName, t => t.MapFrom(source => source.Name));
            CreateMap<UserDTO, User>()
                .ForMember(dist => dist.Name, t => t.MapFrom(source => source.UserName));
        }
    }
}
