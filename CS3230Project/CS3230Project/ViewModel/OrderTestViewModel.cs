using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Annotations;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Binds the order tests form to the model
    /// </summary>
    public class OrderTestViewModel : INotifyPropertyChanged
    {
        private const int NullSelectedTestIndex = -1;
        private string testToAdd;
        private int selectedTestIndex = NullSelectedTestIndex;
        private ObservableCollection<string> availableTests;
        private ObservableCollection<string> orderedTests;
        private bool canAddAllTests;
        private bool canRemoveTest;
        private bool canAddTest = true;

        /// <summary>
        ///     Gets or sets the testToAdd.
        /// </summary>
        /// <value>
        ///     The testToAdd.
        /// </value>
        public string TestToAdd { 
            get => this.testToAdd;
            set
            {
                this.testToAdd = value;
                this.CanAddTest = value != null;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the index of the selected test.
        /// </summary>
        /// <value>
        /// The index of the selected test.
        /// </value>
        public int SelectedTestIndex
        {
            get => this.selectedTestIndex;
            set
            {
                this.selectedTestIndex = value;
                this.CanRemoveTest = value != NullSelectedTestIndex;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the available tests.
        /// </summary>
        /// <value>
        /// The available tests.
        /// </value>
        public ObservableCollection<string> AvailableTests
        {
            get => this.availableTests;
            set
            {
                this.availableTests = value;

                var testsAvailable = value != null;

                this.CanAddAllTests = testsAvailable;
                this.CanRemoveTest = testsAvailable;

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     ets or sets the ordered tests.
        /// </summary>
        /// <value>
        /// The ordered tests.
        /// </value>
        public ObservableCollection<string> OrderedTests
        {
            get => this.orderedTests;
            set
            {
                this.orderedTests = value;

                var testsAvailable = value != null;

                this.CanAddAllTests = testsAvailable;
                this.CanRemoveTest = testsAvailable;

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can add all tests.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can add all tests; otherwise, <c>false</c>.
        /// </value>
        public bool CanAddAllTests
        {
            get => this.canAddAllTests;
            set
            {
                this.canAddAllTests = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether this instance can add testToAdd.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can add testToAdd; otherwise, <c>false</c>.
        /// </value>
        public bool CanAddTest
        {
            get => this.canAddTest;
            set
            {
                this.canAddTest = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance can remove testToAdd.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can remove testToAdd; otherwise, <c>false</c>.
        /// </value>
        public bool CanRemoveTest
        {
            get => this.canRemoveTest;
            set
            {
                this.canRemoveTest = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets the appointment date.
        /// </summary>
        /// <value>
        ///     The appointment date.
        /// </value>
        public DateTime AppointmentDate { get; }

        /// <summary>
        ///     Gets the patient identifier.
        /// </summary>
        /// <value>
        ///     The patient identifier.
        /// </value>
        public int PatientId { get; }

        /// <summary>
        ///     Gets the name of the patient.
        /// </summary>
        /// <value>
        ///     The name of the patient.
        /// </value>
        public string PatientName { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderTestViewModel"/> class.
        /// </summary>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="patient">The patient.</param>
        public OrderTestViewModel(DateTime appointmentDate, Patient patient)
        {
            this.AppointmentDate = appointmentDate;
            this.PatientId = patient.PatientId;
            this.PatientName = $"{patient.Fname} {patient.Lname}";
            this.retrieveAvailableTests();
            this.orderedTests = new ObservableCollection<string>();
            this.testToAdd = this.availableTests.FirstOrDefault();
        }

        private void retrieveAvailableTests()
        {
            var availableTests = new ObservableCollection<string>();
            availableTests.Add("Whoop whoop");


            this.availableTests = availableTests;
        }

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddAllTests()
        {

        }

        public void RemoveSelectedTest()
        {
            this.orderedTests.Remove(this.TestToAdd);
            this.availableTests.Add(this.TestToAdd);
            this.OrderedTests = this.orderedTests;
            this.AvailableTests = this.availableTests;
            this.OnPropertyChanged();
        }

        public void AddTest()
        {
            this.orderedTests.Add(this.TestToAdd);
            this.availableTests.Remove(this.TestToAdd);
            this.OrderedTests = this.orderedTests;
            this.AvailableTests = this.availableTests;
            this.OnPropertyChanged();
        }
    }
}
