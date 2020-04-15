using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dynamic
{
    public static class UIHtmlValidationAttributes
    {
        public static void AddRequiredHtmlAttributes(this TagBuilder tg, MhValidationProperty req)
        {
            tg.MergeAttribute("data-val", "true");
            tg.MergeAttribute("data-val-required", req.ErrorMessage); // This may be not required if not a must to fill the field
        }

        public static void AddStringHtmlAttributes(this TagBuilder tg, MhValidationProperty sl)
        {
            tg.MergeAttribute("data-val-length", sl.ErrorMessage);
            tg.MergeAttribute("data-val-length-max", sl.StringLengthMax.ToString());
            if (sl.StringLengthMin != 0)
            {
                tg.MergeAttribute("data-val-length-min", sl.StringLengthMin.ToString());
            }
            tg.MergeAttribute("maxlength", sl.StringLengthMax.ToString());
        }
        public static void AddRangeHtmlAttributes(this TagBuilder tg, MhValidationProperty range)
        {
            tg.MergeAttribute("data-val-range", range.ErrorMessage);
            tg.MergeAttribute("data-val-range-max", range.RangeMaximumValue.ToString());
            tg.MergeAttribute("data-val-range-min", range.RangeMinimumValue.ToString());
        }

        public static void AddRegEx(this TagBuilder tg, MhValidationProperty regEx)
        {
            tg.MergeAttribute("data-val-regex", regEx.ErrorMessage);
            tg.MergeAttribute("data-val-regex-pattern", regEx.Pattern);
        }

        //Add to Span of the Field only
        public static void AddValidationMessage(this TagBuilder tg, string forFieldName)
        {
            tg.MergeAttribute("data-valmsg-for", forFieldName);
            tg.MergeAttribute("data-valmsg-replace", "true");
            tg.AddCssClass("field-validation-valid text-danger");
        }

    }
}

