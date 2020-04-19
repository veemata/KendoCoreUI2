using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MH.PLCM.Core.Web
{
    [HtmlTargetElement("Dialog-Delete")]
    public class BootStrapModelDialog : TagHelper
    {

        public string DialogTitle { get; set; } = "Information Dialog";
        public string DialogMessage { get; set; } = "Are you sure you want to Delete ?";

        public string DeleteButtonText { get; set; } = "Delete";
        public string CancelButtonText { get; set; } = "Cancel";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
        
        }
    }
}
