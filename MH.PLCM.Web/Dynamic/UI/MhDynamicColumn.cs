using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dynamic
{
    public class MhDynamicColumn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string DisplayLabel { get; set; }
        public List<MhValidationProperty> ValidationProperties { get; set; }
        public int LookUpId { get; set; }
        public int ReportGroupId { get; set; }
        public int GroupOrder { get; set; }
        public string DefaultValue { get; set; }
        public string UnitOfMessure { get; set; }
        public int ResponsibleGroupId { get; set; }
        public bool Active { get; set; }
    }
}
