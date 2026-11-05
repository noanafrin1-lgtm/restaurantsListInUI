using restaurantsListInUI.Services;
//using restaurantsListInUI.Views;
//using restaurantsListInUI.Models;

using System.Text.RegularExpressions;

namespace restaurantsListInUI.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void btnRegister(object sender, EventArgs e)
    {
        string email = entryEmail.Text;
        string password = entryPassword.Text;
        string password2 = entryPassword2.Text;
        string fullName = entryFullName.Text;



        errPassword.Text = "";
        errEmail.Text = "";
        errPassword2.Text = "";
        errFullName.Text = "";

        bool isFormValid = true;

        // full name Empty Validation
        if (fullName == null || fullName == "")
        {
            errFullName.Text = "Name can not be empty";
            isFormValid = false;
            return;
        }

        // Email Empty Validation
        if (email == null || email == "")
        {
            errEmail.Text = "Email can not be empty";
            isFormValid = false;
            return;
        }


        // Password Empty Validation
        if (password == null || password == "")
        {
            errPassword.Text = "password can not be empty";
            isFormValid = false;
            return;
        }
        // Password2 Empty Validation
        if (password2  == null || password2 == "")
        {
            errPassword2.Text = "password 2 can not be empty";
            isFormValid = false;
            return;
        }

        if (password2 != password)
        {
            errPassword2.Text = "passwords are not the same";
            isFormValid = false;
            return;
        }

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errEmail.Text = "you need @ and . in your email";
            isFormValid = false;
        }
        if (!Regex.IsMatch(email, @"^.{5,}$"))
        {
            errEmail.Text = "email is too short";
            isFormValid = false;
        }

        if (isFormValid)
        {
            await Shell.Current.GoToAsync("//RestaurantAsListPage");
        }
        //else
        //{
        //    errPassword2.Text = "problem with email or password";
        //}
    }

    private async void btnSwithPageToLogin(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }
}