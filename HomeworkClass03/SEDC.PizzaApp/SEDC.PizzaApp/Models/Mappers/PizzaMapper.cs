using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel PizzaViewModel (Pizza pizza)
        {
            return new PizzaViewModel
            {
              id = pizza.Id,
              Pizza = pizza.Name,
              Price = pizza.Price,
              PizzaSize = pizza.PizzaSize
            };
        }
    }
}
