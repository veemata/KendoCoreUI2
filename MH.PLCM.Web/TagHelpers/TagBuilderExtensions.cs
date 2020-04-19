using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MH.PLCM.TagHelpers
{
    public static class TagBuilderExtensions
    {
        public static string GetString(this TagBuilder tb)
        {
            using (var writer = new System.IO.StringWriter())
            {
                tb.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }
    }
}
