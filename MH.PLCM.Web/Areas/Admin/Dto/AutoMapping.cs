using AutoMapper;
using MH.PLCM.Core.Entities;

namespace MH.PLCM.Models.Dtos
{

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Permission, Permission>(); // means you want to map from User to UserDTO
        }
    }
}
