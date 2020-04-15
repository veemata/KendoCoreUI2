using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Northwind.Entities
{
    [Table("UserSettings")]
    public class UserSetting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(8)]
        public string SettingKey { get; set; }

        [Required]
        public int SettingSeq { get; set; }

        [Required]
        public string SettingValue { get; set; }

        public byte[] SettingBinary { get; set; }

    }
}
