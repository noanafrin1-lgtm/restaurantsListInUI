using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace restaurantsListInUI.ViewModels
{
    internal class RegisterPageViewModel
    {
       // ICommand RegisterCommand { get; set; }
        ICommand GoToLoginCommand { get; set; }
        public RegisterPageViewModel() {
            //RegisterCommand = new Command(TryRegister);
            GoToLoginCommand = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
        }
        
 
    //private async void TryRegister()
    //    {

    //    }
    }
}
