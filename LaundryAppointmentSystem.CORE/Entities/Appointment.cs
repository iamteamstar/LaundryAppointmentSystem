using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.Entities
{
	public class Appointment
	{
		public int ID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }
		public int StudentID { get; set; }
		public Student Students { get; set; }
		public int MachineID { get; set; }
		public Machine Machine { get; set; }
	}
}
