using AutoMapper;
using MH.PLCM.Core.Entities;

namespace MH.PLCM.Areas.Admin.Mapping
{

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AppPermission, AppPermission>(); // means you want to map from User to UserDTO
        }
    }
}
