using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using restaurantsListInUI.Services;
using System.Text.RegularExpressions;

namespace restaurantsListInUI.ViewModels
{
    internal class LoginPageViewModel : ViewModelBase
    {
        public ICommand SubmitLoginCommand {  get; set; }
        public ICommand GoToRegisterCommand { get; set; }
        public ICommand ToggleViewPasswordCommand { get; set; }

        public LoginPageViewModel()
        {
            IsHidePassword = false;
            SubmitLoginCommand = new Command(TryLogin);
            GoToRegisterCommand = new Command(async () => await Shell.Current.GoToAsync("//RegisterPage"));
            ToggleViewPasswordCommand = new Command(TogglePassword);
        }

        private bool isHidePassword;
        public bool IsHidePassword
        {
            get => isHidePassword; 
            set {
                if (value == isHidePassword) return;
                isHidePassword = value;
              
                OnPropertyChanged();
            }
        }


        private string entryEmail = "";
        public string EntryEmail
        {
            get => entryEmail;
            set
            {
                if (entryEmail == value) return;
                entryEmail = value;
                OnPropertyChanged();
            }
        }
        private string entryPassword = "";
        public string EntryPassword
        {
            get => entryPassword;
            set
            {
                if (entryPassword == value) return;
                entryPassword = value;
                OnPropertyChanged();
            }
        }

        private string errEmail = "";
        public string ErrEmail
        {
            get => errEmail;
            set
            {
                if (errEmail == value) return;
                errEmail = value;
                OnPropertyChanged();
            }
        }
        private string errPassword = "";
        public string ErrPassword
        {
            get => errPassword;
            set
            {
                if (errPassword == value) return;
                errPassword = value;
                OnPropertyChanged();
            }
        }

        private void TogglePassword()
        {
            IsHidePassword = !IsHidePassword;
        }
        public async void TryLogin()
        {
            string email = EntryEmail;
            string password = EntryPassword;

            ErrPassword = "";
            ErrEmail = "";

            bool isFormValid = true;

            if (email == null || email == "")
            {
                ErrEmail = "Email can not be empty";
                isFormValid = false;
                return;
            }
            if (password == null || password == "")
            {
                ErrPassword = "password can not be empty";
                isFormValid = false;
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ErrEmail = "yoa need @ and . in your email";
                isFormValid = false;
            }
            if (!Regex.IsMatch(email, @"^.{5,}$"))
            {
                ErrEmail = "email is too short";
                isFormValid = false;
            }
            if (isFormValid)
            {
                bool succeed = DataRepository.CheckUserAuth(email, password);
                if (succeed)
                {
                    // you r in -> goto another page
                    await Shell.Current.GoToAsync("//RestaurantAsListPage");
                }
                else
                {
                    ErrPassword = "problem with email or password";
                    // failed
                }
            }
        }
    }
}
