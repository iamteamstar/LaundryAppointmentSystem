using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.Entities
{
	public class LoundryMachine
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; }//iamteamstar: bozuk-çalışıyor
		public List<Appointment> Appointment { get; set; }
		private readonly List<LoundryMachine> loundryMachines = new List<LoundryMachine>();
	}
}
