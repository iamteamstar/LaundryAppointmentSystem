using LaundryAppointmentSystem.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppointmentSystem.CORE.IServices
{
	public interface IAppointmentService
	{
		IQueryable<LoundryMachine> GetAvailableMachines(DateTime avalabilityDate);
		ValueTask<string> AddAppointment(int userId,int machineId,DateTime startDateTime, DateTime finishDateTime);
	}
}
