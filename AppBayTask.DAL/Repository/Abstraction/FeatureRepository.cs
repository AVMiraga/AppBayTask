using AppBayTask.Core.Entities;
using AppBayTask.DAL.Context;
using AppBayTask.DAL.Repository.Interfaces;

namespace AppBayTask.DAL.Repository.Abstraction
{
	public class FeatureRepository : Repository<Feature>, IFeatureRepository
	{
		public FeatureRepository(AppDbContext context) : base(context)
		{
		}
	}
}
