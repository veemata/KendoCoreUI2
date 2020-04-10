using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System;

namespace Dynamic
{
    public static class GetDynamicHtml
    {
        public static string ForFormControl(MhEntityDynanicRow mdR)
        {


            var divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("form-group");

            divBuilder.InnerHtml.AppendHtml(ForLable(mdR.ColumnType.Name, mdR.ColumnType.DisplayLabel));
            divBuilder.InnerHtml.AppendHtml(ForTextBox(mdR.ColumnType.Name, mdR.ColumnValue, mdR.ColumnType.ValidationProperties)); ;
            divBuilder.InnerHtml.AppendHtml(ForValidator(mdR.ColumnType.Name));

            string result = divBuilder.GetString();
            return (result);
        }
        public static string ForLable(string lblFor, string lblText)
        {
            var lblBuilder = new TagBuilder("lable");
            lblBuilder.AddCssClass("control-label");
            lblBuilder.MergeAttribute("for", lblFor);
            lblBuilder.InnerHtml.Append(lblText);
            lblBuilder.RenderEndTag();
            return (lblBuilder.GetString());
        }
        public static string ForTextBox(string name, string value, List<MhValidationProperty> vals)
        {
            var inputBuilder = new TagBuilder("input");
            inputBuilder.MergeAttribute("id", name);
            inputBuilder.MergeAttribute("type", "text");
            inputBuilder.MergeAttribute("value", value);
            inputBuilder.MergeAttribute("name", name);
            inputBuilder.AddCssClass("form-control");
            if(! (vals is null))
            {
                foreach (MhValidationProperty vat in vals)
                {
                    switch (vat.Type)
                    {
                        case ValidationType.Required:
                            inputBuilder.AddRequiredHtmlAttributes(vat);
                            break;
                        case ValidationType.RegEx:
                            inputBuilder.AddRegEx(vat);
                            break;
                        case ValidationType.RanageInt:
                            inputBuilder.AddRangeHtmlAttributes(vat);
                            break;
                        case ValidationType.RangeDouble:
                            inputBuilder.AddRangeHtmlAttributes(vat);
                            break;
                        case ValidationType.RangeFloat:
                            inputBuilder.AddRangeHtmlAttributes(vat);
                            break;
                        case ValidationType.String:
                            inputBuilder.AddStringHtmlAttributes(vat);
                            break;
                        case ValidationType.Phone:
                            break;
                        case ValidationType.Email:
                            break;
                    }
                }
            }

            inputBuilder.RenderEndTag();

            return (inputBuilder.GetString());
        }
        public static string ForValidator(string valFor)
        {
            var val = new TagBuilder("span");
            val.AddValidationMessage(valFor);
            val.RenderEndTag();
            return (val.GetString());
        }
        public static string GetString(this TagBuilder tagBuilder)
        {
            using (var writer = new StringWriter())
            {
                tagBuilder.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                return (writer.ToString());
            }
        }
    }
}
