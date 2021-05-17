using AutoMapper;
using PruebaTecnica.Desarrollo.Users.API.Models;
using PruebaTecnica.Desarrollo.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Desarrollo.Users.API.Infrastructure.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //CreateMap<UserModel, UserEntity>().
            //   ConstructUsing(x =>
            //                    new UserEntity(x.Name,
            //                                   x.LastName,
            //                                   x.UserName,
            //                                   x.Password,
            //                                   x.RoleId)).
            //                    ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<LoginModel, UserEntity>().
               ConstructUsing(x =>
                                new UserEntity(string.Empty,
                                               string.Empty,
                                               string.Empty,
                                               x.UserName,
                                               x.Password,
                                               DateTime.Now,
                                               string.Empty,
                                               false))
                                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<UserModel, UserEntity>().
               ConstructUsing(x =>
                                new UserEntity(x.Id,
                                               x.Name,
                                               x.LastName,
                                               x.UserName,
                                               x.Password,
                                               x.CreateAt.Value,
                                               x.RoleId,
                                               x.Active)).
                                ForMember(dest => dest.Password, opt => opt.Ignore());


            CreateMap<UserEntity, UserModel>().
                ForMember(dest => dest.Id,
                          opt => opt.MapFrom(src => src.UserId)).
                ForMember(dest=> dest.RoleName, 
                          opt => opt.MapFrom(src=> src.Role.Name));
        }
    }
}
