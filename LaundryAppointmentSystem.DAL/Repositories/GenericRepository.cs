using LaundryAppointmentSystem.CORE.IServices;
using LaundryAppointmentSystem.DAL.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LaundryAppointmentSystem.DAL.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;
		public GenericRepository(AppDbContext context)
		{
			_context= context;
			_dbSet= _context.Set<T>();//tablolara dinamik erişim(Araştır)
		}
		public async ValueTask AddAsync(T entity)
		{
		await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
		_dbSet.Remove(entity);
		}

		public IQueryable<T> GetAll()
		{
			return _dbSet.AsNoTracking().AsQueryable();//Performans için AsNoTracking eklendi
		}

		public async ValueTask<T> GetByIdAsync(int id)
		{
		return await _dbSet.FindAsync(id);//FirstOrDefault yerine FindAsync kullanman performansı artırır çünkü FindAsync önce bellekte (RAM'de) bu ID'ye sahip veri var mı diye bakar, yoksa veritabanına gider.
		}

		public void Update(T entity)
		{
			_context.Entry(entity).State=EntityState.Modified;//Bu, sadece değişen alanların güncellenmesini sağlayan, çok daha performanslı ve profesyonel bir yöntemdir.
		}
	}
}
