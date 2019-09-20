using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Odie's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Jacques's", Cuisine = CuisineType.French},
                new Restaurant {Id = 3, Name = "Bombay Palace", Cuisine = CuisineType.Indian}
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = GetRestaurantById(restaurant.Id);

            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        //A List type implements the IEnumerable interface
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
