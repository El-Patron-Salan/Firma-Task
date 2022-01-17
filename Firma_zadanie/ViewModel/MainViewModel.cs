using Firma_zadanie.Model;
using Firma_zadanie.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Firma_zadanie.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Worker> _workers = new ObservableCollection<Worker>();
        public ObservableCollection<Worker> Workers 
        {
            get 
            {
                return _workers;
            }
            set 
            {
                if(_workers != value)
                {
                    _workers = value;
                    NotifyPropertyChanged(nameof(Workers));
                }
            }
        }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeContract { get; set; }
        public int EmployeeOvertime { get; set; } = default;

        public ICommand AddEmployeeCommand 
        { 
            get
            {
                return new AddEmployeeCommand();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
