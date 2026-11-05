using restaurantsListInUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Location = restaurantsListInUI.Models.Location;


namespace restaurantsListInUI.Services
{
    internal class DataRepository
    {
        static public User authUser;

        static List<Restaurant> restaurants = new List<Restaurant>();
        static List<User> users = new List<User>();
        
        public static void FillFakeData()
        {
            Location l1 = new Location() { LocationName = "Merkas Sharona TelAviv", X = 354, Y = 3276373 };
            Location l2 = new Location() { LocationName = "Ganden Natanya", X = 34554, Y = 3273456346373 };
            Location l3 = new Location() { LocationName = "Piano Natanya", X = 12354, Y = 32734563 };

            Dictionary<string, RestType> typesDict = new Dictionary<string, RestType>();
            typesDict["marocan"] = new RestType() { Name = "marocan", Icon = "maroccoflag.png" };
            typesDict["yeminith"] = new RestType() { Name = "yeminith", Icon = "yeminith.png" };
            typesDict["romantic"] = new RestType() { Name = "romantic", Icon = "heart.jpg" };
            typesDict["italian"] = new RestType() { Name = "italian", Icon = "italian.png" };
            typesDict["fastFood"] = new RestType() { Name = "fastFood", Icon = "dotnet_bot.png" };

            restaurants.Add(new Restaurant() { RestName = "Shuarma Shemesh", CostLevel = 3, Kosher = true, Place = l2, Image = "heart.jpg", RestaurantTypes = new List<RestType>() { typesDict["romantic"], typesDict["yeminith"] } });
            restaurants.Add(new Restaurant() { RestName = "RomanSea", CostLevel = 4, Kosher = false, Place = l1, Image = "heart.jpg", RestaurantTypes = new List<RestType>() { typesDict["romantic"] } });
            restaurants.Add(new Restaurant() { RestName = "Joya", CostLevel = 4, Kosher = true, Place = l3, Image = "italy.jpg", RestaurantTypes = new List<RestType>() { typesDict["italian"], typesDict["romantic"] } });
            restaurants.Add(new Restaurant() { RestName = "mcdonalds", CostLevel = 2, Kosher = false, Place = l2,Image="" ,RestaurantTypes = new List<RestType>() { typesDict["fastFood"] } });
            users = new List<User>();

            users.Add(new User()
            {
                FullName = "Isarel Yohana",
                Email = "a@a.com",
                Password = "123",
                // BirthDay = new DateTime(30, 4, 2009)
            });

            users.Add(new User()
            {
                FullName = "Noa Nafrin",
                Email = "noa@gmail.com",
                Password = "n123",
               // BirthDay = new DateTime(30, 4, 2009)
            });

            //users.Add(new User()
            //{
            //    FName = "Noa",
            //    PName = "Nafrin",
            //    Email = "noa@gmail.com",
            //    Password = "n123",
            //    BirthDay = new DateTime(30, 4, 2009)
            //});
            //users.Add(new User()
            //{
            //    PName = "Agam",
            //    FName = "Cohen",
            //    Email = "agam11@gmail.com",
            //    Password = "agam123",
            //    BirthDay = new DateTime(25, 9, 2005)
            //});
            //users.Add(new User()
            //{
            //    PName = "Nofar",
            //    FName = "Levi",
            //    Email = "nofarLevi@gmail.com",
            //    Password = "nof12",
            //    BirthDay = new DateTime(6, 7, 2012)
            //});
        }

        public static bool CheckUserAuth(string email, string password)
        {
            var user = users.Find(x => x.Email.ToLower() == email.ToLower() && x.Password == password);
            if(user!=null)
            {
                authUser=user;
                return true;
            }
            authUser = null;
            return false;
        }


        public static List<User> GetUsersList()
        {
            return users;
        }

        public static List<Restaurant> GetRestaurantList()
        {
            return restaurants;
        }

    }
}
