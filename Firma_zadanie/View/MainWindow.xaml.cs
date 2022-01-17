using Firma_zadanie.Model;
using Firma_zadanie.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Firma_zadanie.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel employees = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //var employees = new MainViewModel();
            employees.Workers = new ObservableCollection<Worker>
            {
                new Worker("Alan", "Kolo", "Employee"),
                new Worker("Michal", "Raba"),
                new Worker("Konrad", "Milord")
            };
            this.DataContext = employees;
        }

        #region Codebehind...
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridEmployees.SelectedItem != null)
            {
                employees.Workers.Remove(DataGridEmployees.SelectedItem as Worker);
            }
        }
        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridEmployees.SelectedItem != null)
            {
                (DataGridEmployees.SelectedItem as Worker).ChangeContract();
            }
        }
        #endregion //TO-DO: implement RelayCommand or find some way to get rid of these events
    }
}
