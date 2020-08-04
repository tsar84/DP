using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechnicalInspectionApp.Model.Entities;
using TechnicalInspectionApp.Model.Repositories;

namespace TechnicalInspectionApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    
        
        public partial class RegistrationWindow : Window, INotifyPropertyChanged
    {
            RegistrationRepository regRep = new RegistrationRepository();
            public RegistrationWindow()
            {
                InitializeComponent();
                regRep = new RegistrationRepository();
                DataContext = this;
            }

            private List<Registration> _regs;
            public List<Registration> Registrations
            {
                get
                {
                    _regs = regRep.GetRegistrations();
                    return _regs;
                }
                set
                {
                    _regs = value;
                    OnPropertyChanged("Registrations");
                }
            }
            private Registration _selectedRegistration;
            public Registration SelectedRegistration
            {
                get
                {
                    return _selectedRegistration;
                }
                set
                {
                    _selectedRegistration = value;
                    OnPropertyChanged("SelectedRegistration");
                }
            }

            private RelayCommand addCommand;
            public RelayCommand AddCommand
            {
                get
                {
                    return addCommand ??
                      (addCommand = new RelayCommand(obj =>
                      {
                          AddRegistrationWindow addRegistrationWindow = new AddRegistrationWindow();
                          addRegistrationWindow.ShowDialog();
                          UpdateData();
                      }, (obj) => true));
                }
            }

            private RelayCommand editCommand;
            public RelayCommand EditCommand
            {
                get
                {
                    return editCommand ??
                      (editCommand = new RelayCommand(obj =>
                      {
                          AddRegistrationWindow addRegistrationWindow = new AddRegistrationWindow(SelectedRegistration);
                          addRegistrationWindow.ShowDialog();
                          UpdateData();
                      }, (obj) => SelectedRegistration != null));
           
                }
            }

            private RelayCommand deleteCommand;
            public RelayCommand DeleteCommand
            {
                get
                {
                    return deleteCommand ??
                      (deleteCommand = new RelayCommand(obj =>
                      {
                          if (MessageBox.Show($"Вы действительно хотите удалить {SelectedRegistration.Login} {SelectedRegistration.Password} ?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                          {
                              regRep.DeleteRegistration(SelectedRegistration);
                              UpdateData();
                          }
                      }, (obj) => SelectedRegistration != null));
                }
            }

            private void UpdateData()
            {
            _regs.Clear();
            Registrations = regRep.GetRegistrations();
            }
            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
 }






