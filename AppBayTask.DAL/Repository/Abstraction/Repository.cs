using AppBayTask.Core.Entities.Common;
using AppBayTask.DAL.Context;
using AppBayTask.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppBayTask.DAL.Repository.Abstraction
{
	public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
	{
		private readonly AppDbContext _context;
		public DbSet<T> Table => _context.Set<T>();

		public Repository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			IQueryable<T> entities = Table;

			return await entities.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			T entity = await Table.FirstOrDefaultAsync(x => x.Id == id);

			return entity;
		}

		public async Task CreateAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public void UpdateAsync(T entity)
		{
			Table.Update(entity);
			entity.UpdatedAt = DateTime.Now;
		}

		public void DeleteAsync(T entity)
		{
			entity.IsDeleted = true;
			entity.UpdatedAt = DateTime.Now;

			Table.Update(entity);
		}

		public async Task<int> SaveChangesAsync()
		{
			var res = await _context.SaveChangesAsync();

			return res;
		}
	}
}
