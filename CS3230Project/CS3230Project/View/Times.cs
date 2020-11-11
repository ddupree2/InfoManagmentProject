using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model;

namespace CS3230Project.View
{
    class Times
    {
        public IList<string> times { get; private set; }

        public Times(Doctor doctor, DateTime selectedDate)
        {
            this.times = new List<string>();
            this.setInitialTimeSlots();
            this.removeUnavaliableTimes(doctor, selectedDate);

        }

        private void setInitialTimeSlots()
        {
            var timesToAdd = new List<string>(){"7:00 AM", "7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM"};
            foreach (var timeSlot in timesToAdd)
            {
                this.times.Add(timeSlot);
            }
        }

        private void removeUnavaliableTimes(Doctor doctor, DateTime selectedDate)
        {
            var appointmentsForSelectedDay = new List<DateTime>();
            foreach (var appointment in doctor.Appointments)
            {
                if (appointment.Date == selectedDate.Date)
                {
                    appointmentsForSelectedDay.Add(appointment);
                }
            }


            foreach (var appointment in appointmentsForSelectedDay)
            {
                var timeToCheck = appointment.ToShortTimeString();
                this.times.Remove(timeToCheck);
            }
        }
    }
}
