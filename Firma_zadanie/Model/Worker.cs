using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_zadanie.Model
{
    public class Worker : INotifyPropertyChanged
    {
        #region Properties
        private string _firstName;
        private string _lastName;
        private string _contract;
        private int _overtime;
        private float _salary;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }
        public string Contract
        {
            get
            {
                if ((_contract == "Internship" && _overtime == 0) || (_contract == "Employee" && _overtime >= 0))
                {
                    return _contract;
                }
                else
                {
                    return "Internship";
                }
            }
            set
            {
                _contract = value;
                NotifyPropertyChanged(nameof(Contract));
            }
        }
        public int Overtime
        {
            get 
            {
                return _overtime;
            }
            set
            {
                _overtime = value < 0 ? 0 : value;
                NotifyPropertyChanged(nameof(Overtime));
            }
        }
        public float Salary
        {
            get
            {
                _salary = CalculateSalary(_overtime, _contract);
                return _salary;
            }
            set
            {
                NotifyPropertyChanged(nameof(Salary));
            }
        }
        #endregion //Properties


        #region Constructors
        public Worker() { }
        public Worker(string firstName, string lastName, string contract = "Internship")
        {
            _firstName = firstName;
            _lastName = lastName;
            _contract = contract;
        }
        #endregion //Constructors

        private float CalculateSalary(int overtime, string contract)
        {
            if (overtime >= 0 && contract == "Employee")
            {
                return (float)Math.Round(4600f + overtime * (4600f / 60f), 2, MidpointRounding.AwayFromZero);
            }
            return 2000f;
        }

        public void ChangeContract()
        {
            if (Contract == "Internship")
            {
                Contract = "Employee";
                Salary = 4600f;
            }
            else
            {
                Contract = "Internship";
                Salary = 2000f;
            }
        }


        #region Overloaded methods
        public string ToString(string firstName, string lastName, float salary)
        {
            return $"{firstName} {lastName} {salary}";
        }
        public string ToString(string firstName, string lastName, string contract, float salary)
        {
            return $"{firstName} {lastName} {contract} {salary}";
        }
        #endregion //Overloaded methods

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
