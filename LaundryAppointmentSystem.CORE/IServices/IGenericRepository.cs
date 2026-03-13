using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.IServices
{
	public interface IGenericRepository<T>where T : class
	{
		//tüm verileri getiren metot
		IQueryable<T> GetAll();
		//id ye göre getiren metot
		ValueTask<T> GetByIdAsync(int id);
		ValueTask AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
