namespace MH.PLCM.Core.Entities
{
    public class RolePermission
    {
        public int ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }


        public int PermissionId { get; set; }
        public Permission Permission { get; set; }



    }
}
