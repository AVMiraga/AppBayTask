using FluentValidation;

namespace AppBayTask.Business.ViewModels
{
	public class FeatureCreateVm
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }
	}

	public class FeatureCreateVmValidator : AbstractValidator<FeatureCreateVm>
	{
		public FeatureCreateVmValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty()
				.WithMessage("Not Valid Title")
				.MaximumLength(20)
				.WithMessage("Max Length can't be more than 20");

			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("Not Valid Description");

			RuleFor(x => x.IconUrl)
				.NotEmpty()
				.WithMessage("Not Valid Icon");
		}
	}
}
