using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder : IRestaurantSeeder
    {
        private readonly RestaurantsDbContext dbContext;

        public RestaurantSeeder(RestaurantsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restaurants);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC specializes in fried chicken with a secret blend of spices.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Nashville Hot Chicken",
                            Description = "Crispy chicken with a spicy Nashville-style sauce.",
                            Price = 10.30M
                        },
                        new Dish
                        {
                            Name = "Zinger Burger",
                            Description = "Spicy chicken fillet burger with fresh lettuce and mayo.",
                            Price = 5.99M
                        },
                        new Dish
                        {
                            Name = "Popcorn Chicken",
                            Description = "Bite-sized, tender chicken pieces, perfect for snacking.",
                            Price = 4.50M
                        }
                    },
                    Address = new Address
                    {
                        City = "London",
                        Street = "Cork St 5",
                        PostalCode = "WC2N SDU"
                    }
                },
                new Restaurant
                {
                    Name = "McDonald's",
                    Category = "Fast Food",
                    Description = "World-famous burgers, fries, and more.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Big Mac",
                            Description = "Two all-beef patties, special sauce, lettuce, cheese, pickles, onions on a sesame seed bun.",
                            Price = 6.49M
                        },
                        new Dish
                        {
                            Name = "McChicken",
                            Description = "Crispy chicken sandwich with lettuce and mayo.",
                            Price = 4.99M
                        },
                        new Dish
                        {
                            Name = "Large Fries",
                            Description = "Golden crispy fries, perfectly salted.",
                            Price = 2.49M
                        }
                    },
                    Address = new Address
                    {
                        City = "New York",
                        Street = "42nd Street",
                        PostalCode = "10036"
                    }
                },
                new Restaurant
                {
                    Name = "Domino's Pizza",
                    Category = "Pizza",
                    Description = "Freshly made pizzas delivered fast and hot.",
                    ContactEmail = "contact@dominos.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Pepperoni Pizza",
                            Description = "Classic pizza with pepperoni and mozzarella cheese.",
                            Price = 12.99M
                        },
                        new Dish
                        {
                            Name = "BBQ Chicken Pizza",
                            Description = "Grilled chicken, BBQ sauce, red onions, and mozzarella.",
                            Price = 14.99M
                        },
                        new Dish
                        {
                            Name = "Garlic Breadsticks",
                            Description = "Soft, oven-baked breadsticks with garlic seasoning.",
                            Price = 5.99M
                        }
                    },
                    Address = new Address
                    {
                        City = "Chicago",
                        Street = "123 Main St",
                        PostalCode = "60601"
                    }
                },
                new Restaurant
                {
                    Name = "Sushi Master",
                    Category = "Japanese",
                    Description = "Authentic Japanese sushi and sashimi.",
                    ContactEmail = "contact@sushimaster.com",
                    HasDelivery = false,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Salmon Sashimi",
                            Description = "Freshly sliced raw salmon served with soy sauce.",
                            Price = 18.99M
                        },
                        new Dish
                        {
                            Name = "California Roll",
                            Description = "Crab meat, avocado, and cucumber rolled in rice and seaweed.",
                            Price = 8.99M
                        },
                        new Dish
                        {
                            Name = "Spicy Tuna Roll",
                            Description = "Tuna mixed with spicy mayo, rolled in seaweed and rice.",
                            Price = 10.49M
                        }
                    },
                    Address = new Address
                    {
                        City = "San Francisco",
                        Street = "Market St 101",
                        PostalCode = "94103"
                    }
                },
                new Restaurant
                {
                    Name = "The Italian Table",
                    Category = "Italian",
                    Description = "Traditional Italian dishes made with fresh ingredients.",
                    ContactEmail = "contact@italiantable.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Margherita Pizza",
                            Description = "Thin crust pizza topped with fresh tomatoes, mozzarella, and basil.",
                            Price = 11.49M
                        },
                        new Dish
                        {
                            Name = "Spaghetti Carbonara",
                            Description = "Classic pasta with eggs, Parmesan, pancetta, and black pepper.",
                            Price = 13.99M
                        },
                        new Dish
                        {
                            Name = "Tiramisu",
                            Description = "Delicious dessert made with espresso-soaked ladyfingers and mascarpone cream.",
                            Price = 6.99M
                        }
                    },
                    Address = new Address
                    {
                        City = "Rome",
                        Street = "Via Veneto 12",
                        PostalCode = "00187"
                    }
                }
            };

            return restaurants;
        }
    }
}
