using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3230Project
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var viewmodel = new ViewModel.ViewModel();

            var address = viewmodel.RegisterAddress("this is an example address","testCity","testState",12345, "2394857436");
            viewmodel.RegisterPatient("testssn","Testfinit","testlname", address);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
