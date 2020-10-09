using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3230Project.Model
{
    class Patient
    {
        public string Ssn;

        public string Fname;

        public string Lname;

        public int AddressID;

        public Patient(string ssn, string fname, string lname, int addressID)
        {
            this.Ssn = ssn;
            this.Fname = fname;
            this.Lname = lname;
            this.AddressID = addressID;
        }
    }
}
