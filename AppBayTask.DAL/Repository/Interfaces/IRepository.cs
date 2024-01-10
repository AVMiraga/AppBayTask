using AppBayTask.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AppBayTask.DAL.Repository.Interfaces
{
	public interface IRepository<T> where T : BaseAuditableEntity, new()
	{
		public DbSet<T> Table { get; }
		public Task<IEnumerable<T>> GetAllAsync();
		public Task<T> GetByIdAsync (int id);
		public Task CreateAsync (T entity);
		public void UpdateAsync (T entity);
		public void DeleteAsync (T entity);

		public Task<int> SaveChangesAsync();
	}
}
