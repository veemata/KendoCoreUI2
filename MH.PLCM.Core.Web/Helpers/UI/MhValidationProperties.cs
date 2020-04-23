namespace MH.PLCM.Core.Dynamic
{
    public class MhValidationProperty
    {

        public ValidationType Type { get; set; }
        public string ErrorMessage { get; set; }

        public double RangeMinimumValue { get; set; }
        public double RangeMaximumValue { get; set; }

        public int StringLengthMax { get; set; }
        public int StringLengthMin { get; set; }

        public string Pattern { get; set; }
    }

    public enum ValidationType
    {
        Required,
        String,
        RanageInt,
        RangeFloat,
        RangeDouble,
        RegEx,
        Phone,
        Email
    }
}
