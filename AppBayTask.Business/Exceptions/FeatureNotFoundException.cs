namespace AppBayTask.Business.Exceptions
{
	public class FeatureNotFoundException : Exception
	{
		public FeatureNotFoundException() : base("Feature not found!")
		{
		}

		public FeatureNotFoundException(string? message) : base(message)
		{
		}
	}
}
