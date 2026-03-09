using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.Entities
{
	public class Machine
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }//iamteamstar: bozuk-çalışıyor
		public List<Appointment> Appointment { get; set; }
	}
}
