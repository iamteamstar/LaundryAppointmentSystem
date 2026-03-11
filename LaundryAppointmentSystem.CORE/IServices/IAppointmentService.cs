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
		IQueryable<Machine> GetAvailableMachines(DateTime avalabilityDate);
		ValueTask<string> AddAppointment(int userId,int machineId,DateTime startDateTime, DateTime finishLongDateTime,DateTime finishShortDateTime);
	}
}
