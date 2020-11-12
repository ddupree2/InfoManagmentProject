using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CS3230Project.ViewModel;

namespace CS3230Project.View
{
    /// <summary>
    ///     Represents a test order form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class orderTestsForm : Form
    {

        private OrderTestViewModel orderTestViewModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="orderTestsForm" /> class.
        /// </summary>
        /// <param name="orderTestsViewModel"></param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="patientID">The patient identifier.</param>
        public orderTestsForm(OrderTestViewModel orderTestsViewModel)
        {
            InitializeComponent();
            this.orderTestViewModel = orderTestsViewModel;
            this.bindToViewModel();
            this.testsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void bindToViewModel()
        {
            this.addAllTestsButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanAddAllTests");
            this.addTestButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanAddTest");
            this.removeSelectedButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanRemoveTest");
            this.testsComboBox.DataBindings.Add("DataSource", this.orderTestViewModel, "AvailableTests");
            this.orderedTestsListBox.DataBindings.Add("DataSource", this.orderTestViewModel, "OrderedTests");
            this.nameLabel.Text = this.orderTestViewModel.PatientName;
            this.patientIdLabel.Text = this.orderTestViewModel.PatientId.ToString();
            this.appointmentDateTimePicker.Value = this.orderTestViewModel.AppointmentDate;
        }

        private void orderedTestsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTestIndex = this.orderedTestsListBox.SelectedIndex;
            this.orderTestViewModel.SelectedTestIndex = selectedTestIndex;
        }

        private void addAllTestsButton_Click(object sender, EventArgs e)
        {
            this.orderTestViewModel.AddAllTests();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            this.orderTestViewModel.RemoveSelectedTest();
        }

        private void addTestButton_Click(object sender, EventArgs e)
        {
            this.orderTestViewModel.AddTest();
        }
    }
}