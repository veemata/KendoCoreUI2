namespace MH.PLCM.Core.Entities
{
    public class ApplicationUserRole
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
