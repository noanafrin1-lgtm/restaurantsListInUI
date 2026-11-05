using restaurantsListInUI.ViewModels;

namespace restaurantsListInUI.Views;

public partial class ExamplePage : ContentPage
{
	public ExamplePage()
	{
		InitializeComponent();
		BindingContext = new ExampleViewModel();
	}
}