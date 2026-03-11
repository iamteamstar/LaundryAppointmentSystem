using LaundryAppointmentSystem.CORE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;


namespace LaundryAppointmentSystem.BUSINESS.Services
{
	public class AppointmentService : IAppointmentService
	{
		public async ValueTask<string>AddAppointment(int userId, int machineId, DateTime startDateTime, DateTime finishLongDateTime, DateTime finishShortDateTime)
		{
			//burada amacım kullanıcı rezervasyon yapabileceği tarihleri görmesi. bunun için bir datetime oluşturmuştuk. kullanıcı buraya geldiyse hakkı var mı yok mu kontrol edelim
			//kontrol için önce kullanıcıyı bulalım ya da bunu studentservive yapsa daha doğru mu olur?
			//biz öncelikle kullanıcının şuandan önceye almasını engelleyelim.
			startDateTime = DateTime.Now;
			finishLongDateTime = startDateTime.AddHours(2).AddMinutes(30);
			finishShortDateTime=startDateTime.AddMinutes(30);
			TimeSpan durationLong=finishLongDateTime-startDateTime;
			TimeSpan durationShort=finishShortDateTime-startDateTime;
			if (startDateTime<DateTime.Now)
			{
				return  "geçmiş zamana rezervasyon alamazsın!";
			}
			if (startDateTime >= finishLongDateTime || finishLongDateTime < DateTime.Now)
			{
				return "geçerli tarih girin!";

			}
			else if (durationLong.TotalMinutes>150|| durationShort.TotalMinutes <30)
			{
				return "lütfen 30 dk ile 150 dk arası bir zaman seçin!";
			}
			else
				return "rezervasyon olusturuldu";
		}

		public IQueryable<Machine> GetAvailableMachines(DateTime avalabilityDate)
		{
			throw new NotImplementedException();
		}
	}
}
