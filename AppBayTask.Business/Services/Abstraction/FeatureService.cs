using AppBayTask.Business.Exceptions;
using AppBayTask.Business.Services.Interfaces;
using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using AppBayTask.DAL.Repository.Interfaces;
using AutoMapper;

namespace AppBayTask.Business.Services.Abstraction
{
	public class FeatureService : IFeatureService
	{
		private readonly IFeatureRepository _repo;
		private readonly IMapper _mapper;

		public FeatureService(IFeatureRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public async Task CreateAsync(FeatureCreateVm featureVm)
		{
			Feature feature = _mapper.Map<Feature>(featureVm);

			await _repo.CreateAsync(feature);
			await _repo.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			Feature feature = await _repo.GetByIdAsync(id);

			_repo.DeleteAsync(feature);
			await _repo.SaveChangesAsync();
		}

		public async Task<IEnumerable<Feature>> FeatureGetAllAsync()
		{
			return await _repo.GetAllAsync();
		}

		public async Task<Feature> FeatureGetAsync(int id)
		{
			var entity = await _repo.GetByIdAsync(id) ?? throw new FeatureNotFoundException();

			return entity;
		}

		public async Task UpdateAsync(FeatureUpdateVm featureVm)
		{
			Feature feature = _mapper.Map<Feature>(featureVm);

			_repo.UpdateAsync(feature);
			await _repo.SaveChangesAsync();
		}
	}
}
