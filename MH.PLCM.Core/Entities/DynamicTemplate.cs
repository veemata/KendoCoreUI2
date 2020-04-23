﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MH.PLCM.Core.Entities
{
    public partial class DynamicTemplate
    {
        public DynamicTemplate()
        {
            DynamicTemplateFeatures = new HashSet<DynamicTemplateFeature>();
        }

        [Key]
        [Column("RowID")]
        public int RowId { get; set; }
        [Required]
        [StringLength(50)]
        public string TemplateName { get; set; }
        [Required]
        public bool? Active { get; set; }

        [InverseProperty(nameof(DynamicTemplateFeature.TemplateRow))]
        public virtual ICollection<DynamicTemplateFeature> DynamicTemplateFeatures { get; set; }
    }
}