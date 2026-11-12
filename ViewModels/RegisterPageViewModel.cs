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
    internal class RegisterPageViewModel : ViewModelBase
    {
        public ICommand RegisterCommand { get; set; }
        public ICommand GoToLoginCommand { get; set; }
        public RegisterPageViewModel() 
        {
            RegisterCommand = new Command(TryRegister);
            GoToLoginCommand = new Command(async () => await Shell.Current.GoToAsync("//LoginPage"));
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

        private string entryPassword1;
        private string EntryPassword1
        {
            get => entryPassword1;
            set
            {
                if (entryPassword1 == value) return;
                entryPassword1 = value;
                OnPropertyChanged();
            }
        }
        private string entryPassword2;
        private string EntryPassword2
        {
            get => entryPassword2;
            set
            {
                if (entryPassword2 == value) return;
                entryPassword2 = value;
                OnPropertyChanged();
            }
        }

        private string entryFullName;
        public string EntryFullName
        {
            get => entryFullName;
            set
            {
                if (entryFullName == value) return;
                entryFullName = value;
                OnPropertyChanged();
            }
        }

        private string errFullName;
        public string ErrFullName
        {
            get => errFullName;
            set
            {
                if (errFullName == value) return;
                errFullName = value;
                OnPropertyChanged();
            }
        }
        private string errEmail;
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
        private string errPassword1;
        public string ErrPassword1
        {
            get => errPassword1;
            set
            {
                if (errPassword1 == value) return;
                errPassword1 = value;
                OnPropertyChanged();
            }
        }
        private string errPassword2;
        public string ErrPassword2
        {
            get => errPassword2;
            set
            {
                if (errPassword2 == value) return;
                errPassword2 = value;
                OnPropertyChanged();
            }
        }


        public async void TryRegister()
        {

            bool isFormValid = true;

            // full name Empty Validation
            if (EntryFullName == null || EntryFullName == "")
            {
                ErrFullName= "Name can not be empty";
                isFormValid = false;
                return;
            }

            // Email Empty Validation
            if (EntryEmail == null || EntryEmail == "")
            {
                ErrEmail = "Email can not be empty";
                isFormValid = false;
                return;
            }


            // Password Empty Validation
            if (EntryPassword1 == null || EntryPassword1 == "")
            {
                ErrPassword1 = "password can not be empty";
                isFormValid = false;
                return;
            }
            // Password2 Empty Validation
            if (EntryPassword2 == null || EntryPassword2 == "")
            {
                ErrPassword2 = "password 2 can not be empty";
                isFormValid = false;
                return;
            }

            if (EntryPassword2 != EntryPassword1)
            {
                ErrPassword2 = "passwords are not the same";
                isFormValid = false;
                return;
            }

            if (Regex.IsMatch(EntryEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ErrEmail = "you need @ and . in your email";
                isFormValid = false;
            }
            if (!Regex.IsMatch(EntryEmail, @"^.{5,}$"))
            {
                ErrEmail = "email is too short";
                isFormValid = false;
            }

            //if (isFormValid)
            //{
            //    await Shell.Current.GoToAsync("//RestaurantAsListPage");
            //}
        }
    }
}
