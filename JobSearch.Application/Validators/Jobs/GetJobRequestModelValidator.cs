using FluentValidation;
using JobSearch.Application.ViewModel.Jobs;

namespace JobSearch.Application.Validators.Jobs
{
    public class GetJobRequestModelValidator : AbstractValidator<GetJobRequestModel>
    {
        public GetJobRequestModelValidator()
        {
            RuleFor(j => j.Count)
                .GreaterThan(0)
                .NotNull()
                .NotEmpty();
            RuleFor(j => j.Page)
                .GreaterThan(0)
                .NotNull()
                .NotEmpty();
            RuleFor(j => j.Title)
                .MaximumLength(100);
            RuleFor(j => j.City)
                .MaximumLength(100);
            RuleFor(j => j.EmploymentType)
                .IsInEnum();
            RuleFor(j => j.Category)
                .IsInEnum();
        }
    }
}
