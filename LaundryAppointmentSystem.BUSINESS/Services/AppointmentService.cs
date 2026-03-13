using LaundryAppointmentSystem.CORE.IServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using LaundryAppointmentSystem.CORE.Entities;


namespace LaundryAppointmentSystem.BUSINESS.Services
{
	public class AppointmentService : IAppointmentService
	{
		public async ValueTask<string>AddAppointment(int studentId, int machineId, DateTime startDateTime, DateTime finishDateTime)
		{
			//burada amacım kullanıcı rezervasyon yapabileceği tarihleri görmesi. bunun için bir datetime oluşturmuştuk. kullanıcı buraya geldiyse hakkı var mı yok mu kontrol edelim
			//kontrol için önce kullanıcıyı bulalım ya da bunu studentservive yapsa daha doğru mu olur?
			//kural-1: öğrenci geçmiş zamana randevu alamaz
			TimeSpan totalDateTime = finishDateTime-startDateTime;//Alternatif:TimeSpan totalDateTime = finishDateTime.Subtract(startDateTime);
			if (startDateTime <= DateTime.Now || finishDateTime <= startDateTime)
			{
				return "lütfen geçerli aralıkta randevu almaya çalışın";
			}
			else if (totalDateTime.TotalMinutes <= 29 || totalDateTime.TotalMinutes >= 151)
			{
				return "maks 150 ve min 30 dk lik randevu oluşturabilirsiniz";
			}
			//kural-2:istediği saaatte makineler müsait değilse yine randevu oluşturamaz. sıra sıra gidelim
			// Sanki veritabanından (DbSet üzerinden) makineleri çekmişiz gibi düşünelim:
			List<LoundryMachine> mockMachines = new List<LoundryMachine>
			{
			new LoundryMachine	{ID=1,Name="machine1",IsActive=true},
			new LoundryMachine	{ID=2,Name="machine2",IsActive=true},
			new LoundryMachine	{ID=3,Name="machine3",IsActive=false}//bozuk makine
			};
			var machine = mockMachines.FirstOrDefault(x => x.ID == machineId);

			if (machine == null)
				return "makine müsait değil";
			else if (machine.IsActive == false)
				return "makine bozuk";

			List<Appointment> mockAppointment = new List<Appointment>()
			{
				new Appointment()
				{
					ID=1,
					MachineID=1,
					StartDate=new DateTime(2026,09,21,14,0,0),
					FinishDate=new DateTime(2026,09,21,16,0,0)	
				}
			};
			bool statusAppointment=mockAppointment.Any(x=>x.MachineID==machineId&&x.StartDate<finishDateTime&&x.FinishDate>startDateTime);

			if (statusAppointment)
			{
				return "Seçtiğiniz makine bu saatlerde doludur, lütfen başka bir saat seçin.";
			}
			int studentAppointCount=mockAppointment.Count(x=>x.StudentID==studentId);
			if (studentAppointCount >= 2)
			{
				return "maalesef hakkınız yok";
			}
			return "Randevunuz başarıyla oluşturuldu!";
		}
		
		public IQueryable<LoundryMachine> GetAvailableMachines(DateTime avalabilityDate)
		{
			List<LoundryMachine> machineList = new List<LoundryMachine>()
			{
				new LoundryMachine{ID=4,Name="machine4",IsActive=false},
				new LoundryMachine{ID=5,Name="machine5",IsActive=true},
				new LoundryMachine{ID=6,Name="machine6",IsActive=true}
			};

			List<Appointment> mockAppointment = new List<Appointment>()
			{
				new Appointment()
				{
					ID=1,
					MachineID=5,
					StartDate=new DateTime(2026,09,21,14,0,0),
					FinishDate=new DateTime(2026,09,21,16,0,0)
				}
			};
			var machineStatu = machineList.Where(x => x.IsActive == true && !mockAppointment.Any(y =>
				y.MachineID == x.ID && 	y.StartDate <= avalabilityDate && 
				y.FinishDate >= avalabilityDate)).AsQueryable();//metot imzası


			return machineStatu;
		}
	}
}
