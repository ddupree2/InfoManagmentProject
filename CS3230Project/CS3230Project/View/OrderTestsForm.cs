using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CS3230Project.ViewModel;

namespace CS3230Project.View
{
    /// <summary>
    ///     Represents a test order form
    /// </summary>
    /// <seealso cref="Form" />
    public partial class OrderTestsForm : Form
    {
        #region Data members

        private readonly OrderTestViewModel orderTestViewModel;
        private readonly BindingList<string> testOrders;
        private readonly BindingList<string> testsAvailable;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderTestsForm" /> class.
        /// </summary>
        /// <param name="orderTestsViewModel"></param>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="patientID">The patient identifier.</param>
        public OrderTestsForm(OrderTestViewModel orderTestsViewModel)
        {
            this.orderTestViewModel = orderTestsViewModel;
            this.testOrders = new BindingList<string>(this.orderTestViewModel.OrderedTests);
            this.testsAvailable = new BindingList<string>(this.orderTestViewModel.AvailableTests);
            this.InitializeComponent();
            this.bindToViewModel();
            this.testsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion

        #region Methods

        private void bindToViewModel()
        {
            this.addAllTestsButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanAddAllTests", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.addTestButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanAddTest", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.removeSelectedButton.DataBindings.Add("Enabled", this.orderTestViewModel, "CanRemoveTest", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.testsComboBox.DataSource = this.testsAvailable;
            this.testsComboBox.DataBindings.Add("SelectedItem", this.orderTestViewModel, "TestToAdd", true,
                DataSourceUpdateMode.OnPropertyChanged);
            this.orderedTestsListBox.DataSource = this.testOrders;
            this.orderedTestsListBox.DataBindings.Add("SelectedIndex", this.orderTestViewModel, "SelectedTestIndex",
                true, DataSourceUpdateMode.OnPropertyChanged);

            this.nameTextBox.Text = this.orderTestViewModel.PatientName;
            this.patientIDTextBox.Text = this.orderTestViewModel.PatientId.ToString();
            this.appointmentDateLabel.Value = this.orderTestViewModel.AppointmentDate;
        }

        private void addAllTestsButton_Click(object sender, EventArgs e)
        {
            var successfullyAddedAll = this.orderTestViewModel.AddAllTests();
            if (successfullyAddedAll)
            {
                MessageBox.Show(@"All added successfully.");
                this.testOrders.Clear();
            }
            else
            {
                MessageBox.Show(@"One or more tests were unsuccessful in being ordered.");
                foreach (var test in this.testOrders)
                {
                    this.testsAvailable.Add(test);
                }

                this.testOrders.Clear();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }

        protected virtual void removeSelectedButton_Click(object sender, EventArgs e)
        {
            var orderSelected = this.orderedTestsListBox.SelectedItem != null;
            if (orderSelected)
            {
                this.testsAvailable.Add(this.orderedTestsListBox.SelectedItem.ToString());
                this.testOrders.Remove(this.orderedTestsListBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show(@"Must select order before removal.");
            }

            this.updateEnableProperties();
            Debug.WriteLine("Remove:ordered test? " + this.orderTestViewModel.OrderedTests.Any());
            Debug.WriteLine("tests available? " + this.orderTestViewModel.AvailableTests.Any());
        }

        private void addTestButton_Click(object sender, EventArgs e)
        {
            var testExists = this.testsComboBox.SelectedItem != null;
            if (testExists)
            {
                this.testOrders.Add(this.testsComboBox.SelectedItem.ToString());
                this.testsAvailable.Remove(this.testsComboBox.SelectedItem.ToString());
            }

            this.updateEnableProperties();
            Debug.WriteLine("Add:ordered test? " + this.orderTestViewModel.OrderedTests.Any());
            Debug.WriteLine("tests available? " + this.orderTestViewModel.AvailableTests.Any());
        }

        private void updateEnableProperties()
        {
            var areTestsOrdered = this.testOrders.Any();
            var areTestsAvailable = this.testsAvailable.Any();

            this.addTestButton.Enabled = areTestsAvailable;
            this.removeSelectedButton.Enabled = areTestsOrdered;
            this.addAllTestsButton.Enabled = areTestsOrdered;
        }

        #endregion
    }
}