using restaurantsListInUI.Models;
using restaurantsListInUI.Services;

namespace restaurantsListInUI.Views;

public partial class RestaurantAsListPage : ContentPage
{
	public List<Restaurant> restaurants {  get; set; }

	public RestaurantAsListPage()
	{
		InitializeComponent();
		restaurants = DataRepository.GetRestaurantList().ToList();
		BindingContext = this;
    }
    private async void bt_Clicked()
	{
		if(Binding Kosher)

    }
}