using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza
            {
                id = 1,
                Name = "Kapricioza"
            },

            new Pizza
            {
                id = 2,
                Name = "Vegetarijana"
            }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                id = 1,
                FirstName = "Deni",
                LastName = "Stojanovski",
                Address = "Adress01"
            },
            new User
             {
                id = 2,
                FirstName = "Aleksandra",
                LastName = "Davidkovska",
                Address = "Adress2"
            },
        };

        public static List<Orders> Orders = new List<Orders>
        {
            new Orders
            {
                Id = 1,
                PaymentMethod =  PaymentMethod.Card,
                User = new User
                {
                    id = 1,
                    FirstName = "Deni",
                    LastName = "Stojanovski",
                    Address = "Adress01"
                },
                Pizza = new Pizza
                {
                    id = 1,
                    Name = "Kapricioza"
                }
            },

            new Orders
            {
                Id = 2,
                PaymentMethod =  PaymentMethod.Cash,
                User = new User
                {
                    id = 1,
                    FirstName = "Aleksandra",
                    LastName = "Davidkovska",
                    Address = "Adress2"
                },
                Pizza = new Pizza
                {
                    id = 2,
                    Name = "Vegetarijana"
                }
            }

        };
    }
}
