using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;

namespace AppBayTask.Business.Services.Interfaces
{
	public interface IFeatureService
	{
		public Task<IEnumerable<Feature>> FeatureGetAllAsync();
		public Task<Feature> FeatureGetAsync(int id);
		Task CreateAsync(FeatureCreateVm featureVm);
		Task UpdateAsync(FeatureUpdateVm featureVm);
		Task DeleteAsync(int id);
	}
}
