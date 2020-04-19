using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;
using System.Text.Encodings.Web;

namespace MH.PLCM.Core.Web
{
    public class FormEntryTagHelper : TagHelper
    {
        private readonly IHtmlGenerator htmlGenerator;
        private readonly HtmlEncoder htmlEncoder;

        public FormEntryTagHelper(IHtmlGenerator htmlGenerator, HtmlEncoder htmlEncoder)
        {
            this.htmlGenerator = htmlGenerator;
            this.htmlEncoder = htmlEncoder;
        }

        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("class", "form-group");

            using (var writer = new StringWriter())
            {
                WriteLabel(writer);
                WriteInput(writer);
                WriteValidation(writer);
                output.Content.AppendHtml(writer.ToString());
            }
        }

        private void WriteLabel(TextWriter writer)
        {
            var tagBuilder = htmlGenerator.GenerateLabel(
              ViewContext,
              For.ModelExplorer,
              For.Name,
              labelText: null,
              htmlAttributes: new { @class = "control-label" });

            tagBuilder.WriteTo(writer, htmlEncoder);
        }

        private void WriteInput(TextWriter writer)
        {
            var tagBuilder = htmlGenerator.GenerateTextBox(
              ViewContext,
              For.ModelExplorer,
              For.Name,
              value: null,
              format: null,
              htmlAttributes: new { @class = "form-control" });

            tagBuilder.WriteTo(writer, htmlEncoder);
        }

        private void WriteValidation(TextWriter writer)
        {
            var tagBuilder = htmlGenerator.GenerateValidationMessage(
              ViewContext,
              For.ModelExplorer,
              For.Name,
              message: null,
              tag: null,
              htmlAttributes: new { @class = "text-danger" });

            tagBuilder.WriteTo(writer, htmlEncoder);
        }
    }
}
