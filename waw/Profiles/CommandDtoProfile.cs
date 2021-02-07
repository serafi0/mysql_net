using System;
using AutoMapper;
using waw.Models;
using waw.ViewModels;

namespace waw.Profiles
{
    public class CommandDtoProfile : Profile
    {
        public CommandDtoProfile()
        {
            CreateMap<Command, CommandDTO>();

        }
    }
}
