using restaurantsListInUI.Models;
using Location = restaurantsListInUI.Models.Location;

namespace restaurantsListInUI.Views;

public partial class RestaurantListPage : ContentPage
{
    public RestaurantListPage()
    {
        //InitializeComponent();
        Location l1 = new Location() { LocationName = "Merkas Sharona TelAviv", X = 354, Y = 3276373 };
        Location l2 = new Location() { LocationName = "Ganden Natanya", X = 34554, Y = 3273456346373 };
        Location l3 = new Location() { LocationName = "Piano Natanya", X = 12354, Y = 32734563 };



        Dictionary<string, RestType> typesDict = new Dictionary<string, RestType>();
        typesDict["marocan"] = new RestType() { Name = "marocan", Icon = "maroccoflag.png" };
        typesDict["yeminith"] = new RestType() { Name = "yeminith", Icon = "yeminith.png" };
        typesDict["romantic"] = new RestType() { Name = "romantic", Icon = "heart.jpg" };
        typesDict["italian"] = new RestType() { Name = "italian", Icon = "italian.png" };
        typesDict["fastFood"] = new RestType() { Name = "fastFood", Icon = "dotnet_bot.png" };



        List<Restaurant> restaurants = new List<Restaurant>();
        restaurants.Add(new Restaurant() { RestName = "Shuarma Shemesh", CostLevel = 3, Kosher = true, Place = l2, Image = "heart.jpg", RestaurantTypes = new List<RestType>() { typesDict["romantic"], typesDict["yeminith"] } });
        restaurants.Add(new Restaurant() { RestName = "RomanSea", CostLevel = 4, Kosher = false, Place = l1, Image = "heart.jpg", RestaurantTypes = new List<RestType>() { typesDict["romantic"] } });
        restaurants.Add(new Restaurant() { RestName = "Joya", CostLevel = 4, Kosher = true, Place = l3, Image = "italy.jpg", RestaurantTypes = new List<RestType>() { typesDict["italian"], typesDict["romantic"] } });
        ///restaurants.Add(new Restaurant() { RestName = "mcdonalds", CostLevel = 2, Kosher = false, Place = l2,Image="" ,RestaurantTypes = new List<RestType>() { typesDict["fastFood"] } });

        // linq
        //List<Restaurant> searchRomanRest = restaurants.FindAll(res => res.Kosher == true && res.RestaurantTypes.Contains(typesDict["romantic"])).ToList();
        //var searchCostLevel4 = restaurants.FindAll(res => res.CostLevel == 4 && res.RestaurantTypes.Contains(typesDict["romantic"])).ToList();
        //Print(searchRomanRest);
    
        restHolder.Children.Clear();

        foreach (Restaurant rest in restaurants)
        {
            var layout = new HorizontalStackLayout();

            layout.Children.Add(new Image
            {
                Source = rest.Image
            });

            layout.Children.Add(new Label
            {
                Text = rest.RestName,
                TextColor = Colors.Orange
            });

            restHolder.Children.Add(layout);
        }
    }


}
