using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Northwind.Entities
{
    [Table("AppSettingDefinitions")]
    public class DbAppSettingDefinition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Description { get; set; }
        public string Scopes { get; set; }
        public bool IsInherited { get; set; }
        public string SettingDefinitionGroup { get; set; }
        public string DefaultValue { get; set; }
        public string ClientVisibilityProvider { get; set; }
        public string CustomData { get; set; }

    }
}
