using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для AddRegistrationWindow.xaml
    /// </summary>
    public partial class AddRegistrationWindow : Window, INotifyPropertyChanged, IDataErrorInfo
    {

    RegistrationRepository regRep;
        public AddRegistrationWindow(Registration reg = null)
{
    InitializeComponent();
    regRep = new RegistrationRepository();
    DataContext = this;
    if (reg != null)
    {
        _regId = reg.UserId;
        Title = "Редактирование регистрации";
        Login = reg.Login;
        Password = reg.Password;
        
    }
}

private int _regId { get; set; } = -1;

private string _login;
public string Login
{
    get
    {
        return _login;
    }
    set
    {
        _login = value;
        OnPropertyChanged("Login");
    }
}

private string _password;
public string Password
{
    get
    {
        return _password;
    }
    set
    {
        _password = value;
        OnPropertyChanged("Password");
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
              AddRegistration();
              MessageBox.Show("Пользователь успешно сохранен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
              ResetFields();
          }, (obj) => errors.Count == 0));
    }
}

private void AddRegistration()
{
    Registration reg = new Registration
    {
        UserId = _regId,
        Login = Login,
        Password = Password,
        Enabled = true,

    };
    regRep.AddRegistration(reg);
}

public void ResetFields()
{
    Login = string.Empty;
    Password = string.Empty;
   
    
}

#region Validation

private Dictionary<String, List<String>> errors = new Dictionary<string, List<string>>();
public void AddError(string propertyName, string error)
{
    if (!errors.ContainsKey(propertyName))
        errors[propertyName] = new List<string>();

    if (!errors[propertyName].Contains(error))
    {
        errors[propertyName].Insert(0, error);
    }
}

public void RemoveError(string propertyName, string error)
{
    if (errors.ContainsKey(propertyName) &&
        errors[propertyName].Contains(error))
    {
        errors[propertyName].Remove(error);
        if (errors[propertyName].Count == 0) errors.Remove(propertyName);
    }
}

public string Error
{
    get
    {
        return this[string.Empty];
    }
}

public string this[string propertyName]
{
    get
    {
        propertyName = propertyName ?? string.Empty;
        switch (propertyName)
        {
            case "Login":
                if (string.IsNullOrEmpty(Login))
                {
                    AddError("Login", "Необходимо заполнить логин");
                }
                else
                {
                    RemoveError("Login", "Необходимо заполнить логин");
                }
                break;
            case "Password":
                if (string.IsNullOrEmpty(Password))
                {
                    AddError("Password", "Необходимо заполнить поле пароль");
                }
                else
                {
                    RemoveError("Password", "Необходимо заполнить поле пароль");
                }
                break;
            
            
        }
        return (!errors.ContainsKey(propertyName) ? null :
                String.Join(Environment.NewLine, errors[propertyName]));
    }
}
#endregion

public event PropertyChangedEventHandler PropertyChanged;

public void OnPropertyChanged([CallerMemberName] string prop = "")
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
    }
}
