using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurantsListInUI.Models
{
    internal class Restaurant
    {
        public string RestName { get; set; }
        public bool Kosher { get; set; }

        public List<RestType> RestaurantTypes { get; set; }

        public int CostLevel { get; set; }

        public Location Place { get; set; }
        public string Image {  get; set; }
    }
}
