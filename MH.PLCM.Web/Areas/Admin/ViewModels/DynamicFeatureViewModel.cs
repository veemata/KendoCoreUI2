using MH.PLCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MH.PLCM.Areas.Admin.ViewModels
{
    public class DynamicFeatureViewModel
    {
        public int RowId { get; set; }
        public string Description { get; set; }
        public FeatureDataType DataTypeId { get; set; }
        public int? LookupId { get; set; }
        public int ReportGroupId { get; set; }
        public int GroupOrder { get; set; }
        public string DefaultValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public bool IsBaanFeature { get; set; }
        public int ResponsibleGroupId { get; set; }
        public bool? Active { get; set; }
    }
}
