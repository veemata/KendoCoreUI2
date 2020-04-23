using FluentValidation;
using MH.PLCM.Areas.Admin.ViewModels;

namespace MH.PLCM.Areas.Admin.Validators
{
    public class DynamicFeatureViewModelValidator:AbstractValidator<DynamicFeatureViewModel>
    {
        public DynamicFeatureViewModelValidator()
        {
            RuleFor(df => df.RowId).NotEmpty().WithMessage("RowId must be an integer");
            RuleFor(df => df.Description).NotEmpty().MaximumLength(100).MinimumLength(5);
            RuleFor(df => df.DataTypeId).IsInEnum().NotEqual(Core.Entities.FeatureDataType.NotSpecified).WithName("Data Type");
            RuleFor(df => df.UnitOfMeasure).MaximumLength(50);
            RuleFor(df => df.Active).NotEmpty();
        }

    }
}
