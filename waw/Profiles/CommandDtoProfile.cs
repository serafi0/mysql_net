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
            //Source to target
            CreateMap<Command, CommandDTO>();
            CreateMap<CommandDTOCreate, Command>();
            CreateMap<CommandDTOUpdate, Command>();


        }
    }
}
