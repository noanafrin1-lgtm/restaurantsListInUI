using restaurantsListInUI.Models;
using restaurantsListInUI.Services;
using System.Text.RegularExpressions;

namespace restaurantsListInUI.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		entryEmail.Text = "";
		entryPassword.Text = "";

    }

	private async void btnLogin(object sender, EventArgs e)
	{
		string email = entryEmail.Text;
		string password = entryPassword.Text;

		errPassword.Text = "";
		errEmail.Text = "";

		bool isFormValid = true;

		if(email == null || email == "")
		{
			errEmail.Text = "Email can not be empty";
			isFormValid = false;
			return;
		}
		if(password == null || password == "")
		{
			errPassword.Text = "password can not be empty";
			isFormValid = false;
            return;
        }

		if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
		{
			errEmail.Text = "yoa need @ and . in your email";
			isFormValid = false;
		}
		if(!Regex.IsMatch(email, @"^.{5,}$"))
		{
			errEmail.Text = "email is too short";
			isFormValid =false;
		}
		if (isFormValid)
		{
			bool succeed = DataRepository.CheckUserAuth(email, password);
			if (succeed)
			{
				// you r in -> goto another page
				await Shell.Current.GoToAsync("//RestaurantAsListPage");
			} else
			{
				errPassword.Text = "problem with email or password";
				// failed
			}
		}	
	}

    private async void btnSwithPageToRegister(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//RegisterPage");
    }
}