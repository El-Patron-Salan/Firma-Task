using Firma_zadanie.ViewModel;
using Firma_zadanie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_zadanie.Command
{
    public class AddEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // comment for me to understand it - later delete it
            // check if paramater is equal to MainViewModel ? then convert it to MainViewModel and put it inside employeeList : don't do that
            if(parameter is MainViewModel employeeList)
            {
                employeeList.Workers.Add(new Worker(employeeList.EmployeeFirstName, employeeList.EmployeeLastName, employeeList.EmployeeContract) { Overtime = employeeList.EmployeeOvertime});
            }
        }
    }
}
