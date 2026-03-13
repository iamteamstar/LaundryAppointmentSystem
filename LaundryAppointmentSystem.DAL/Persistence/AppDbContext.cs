using LaundryAppointmentSystem.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.DAL.Persistence
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		DbSet<Student> Students{ get; set; }
		DbSet<LoundryMachine> LoundryMachines { get; set; }
		DbSet<Appointment> Appointments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}

	
}
