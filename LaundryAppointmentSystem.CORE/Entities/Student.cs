using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.Entities
{
	public class Student
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string No { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
