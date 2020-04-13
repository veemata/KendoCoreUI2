using AutoMapper;

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
