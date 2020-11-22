using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CS3230Project.Annotations;
using CS3230Project.DAL;
using CS3230Project.Model;

namespace CS3230Project.ViewModel
{
    /// <summary>
    ///     Binds the order tests form to the model
    /// </summary>
    public class OrderTestViewModel : INotifyPropertyChanged
    {
        #region Data members

        private const int NullSelectedTestIndex = -1;
        private string testToAdd;
        private int selectedTestIndex = NullSelectedTestIndex;
        private ObservableCollection<string> availableTests;
        private ObservableCollection<string> orderedTests;
        private bool canAddAllTests;
        private bool canRemoveTest;
        private bool canAddTest;
        private readonly TestDAL testDal;
        private IDictionary<int, string> retrievedTests;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the testToAdd.
        /// </summary>
        /// <value>
        ///     The testToAdd.
        /// </value>
        public string TestToAdd
        {
            get => this.testToAdd;
            set
            {
                if (value == this.testToAdd)
                {
                    return;
                }

                this.testToAdd = value;
                this.CanAddTest = !string.IsNullOrEmpty(value);
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the index of the selected test.
        /// </summary>
        /// <value>
        ///     The index of the selected test.
        /// </value>
        public int SelectedTestIndex
        {
            get => this.selectedTestIndex;
            set
            {
                if (value == this.selectedTestIndex)
                {
                    return;
                }

                this.selectedTestIndex = value;
                this.CanRemoveTest = value != NullSelectedTestIndex;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the available tests.
        /// </summary>
        /// <value>
        ///     The available tests.
        /// </value>
        public ObservableCollection<string> AvailableTests
        {
            get => this.availableTests;
            set
            {
                if (value == this.availableTests)
                {
                    return;
                }

                this.availableTests = value;

                var testsAvailable = value != null && value.Any();

                this.CanAddTest = testsAvailable;

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     ets or sets the ordered tests.
        /// </summary>
        /// <value>
        ///     The ordered tests.
        /// </value>
        public ObservableCollection<string> OrderedTests
        {
            get => this.orderedTests;
            set
            {
                if (value == this.orderedTests)
                {
                    return;
                }

                this.orderedTests = value;

                var testsAvailable = value != null && value.Any();

                this.CanAddAllTests = testsAvailable;
                this.CanRemoveTest = testsAvailable;

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance can add all tests.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance can add all tests; otherwise, <c>false</c>.
        /// </value>
        public bool CanAddAllTests
        {
            get => this.canAddAllTests;
            set
            {
                if (value == this.canAddAllTests)
                {
                    return;
                }

                this.canAddAllTests = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance can add testToAdd.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance can add testToAdd; otherwise, <c>false</c>.
        /// </value>
        public bool CanAddTest
        {
            get => this.canAddTest;
            set
            {
                if (value == this.canAddTest)
                {
                    return;
                }

                this.canAddTest = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance can remove testToAdd.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance can remove testToAdd; otherwise, <c>false</c>.
        /// </value>
        public bool CanRemoveTest
        {
            get => this.canRemoveTest;
            set
            {
                if (value == this.canRemoveTest)
                {
                    return;
                }

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

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderTestViewModel" /> class.
        /// </summary>
        /// <param name="appointmentDate">The appointment date.</param>
        /// <param name="patient">The patient.</param>
        public OrderTestViewModel(DateTime appointmentDate, Patient patient)
        {
            this.AppointmentDate = appointmentDate;
            this.PatientId = patient.PatientId;
            this.PatientName = $"{patient.Fname} {patient.Lname}";
            this.testDal = new TestDAL();
            this.retrieveAvailableTests();
            this.orderedTests = new ObservableCollection<string>();
            this.testToAdd = this.availableTests.FirstOrDefault();
            this.canAddTest = true;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void retrieveAvailableTests()
        {
            this.retrievedTests = this.testDal.RetrieveAvailableTests(this.PatientId, this.AppointmentDate);

            this.availableTests = new ObservableCollection<string>(this.retrievedTests.Values);
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Adds all tests.
        /// </summary>
        /// <returns>true if tests were added and false otherwise.</returns>
        public bool AddAllTests()
        {
            var testsToAdd = this.findTestOrderKeys();
            return this.testDal.OrderTests(testsToAdd, this.PatientId, this.AppointmentDate);
        }

        private List<int> findTestOrderKeys()
        {
            var testKeys = new List<int>();
            foreach (var testKey in this.retrievedTests.Keys)
            {
                if (this.OrderedTests.Contains(this.retrievedTests[testKey]))
                {
                    testKeys.Add(testKey);
                }
            }

            return testKeys;
        }

        #endregion
    }
}