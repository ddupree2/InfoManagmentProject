using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230Project.Model
{
    
    public class Doctor
    {
        public string DoctorId;

        public Employee Employee;

        public IList<DateTime> Appointments = new List<DateTime>();
    

        public Doctor()
        {

        }

        public bool IsDoctor(string doctorID)
        {
            var checker = false || this.DoctorId.Equals(doctorID);

            return checker;
        }
    }
}
