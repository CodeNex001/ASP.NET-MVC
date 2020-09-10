using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "List of orders";
            ViewData.Add("Message",$"The number of orders is: {StaticDb.Orders.Count}");
            List<Orders> orders = StaticDb.Orders;
            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();
            foreach(Orders order in orders)
            {
                //    orderDetailsViewModels.Add
                //(
                //        new OrderDetailsViewModel
                //    {
                //        Id = order.Id,
                //        PaymentMethod = order.PaymentMethod,
                //        PizzaName = order.Pizza.Name,
                //        UserFullName = $"{order.User.FirstName} {order.User.LastName}"

                //    });
                
                orderDetailsViewModels.Add(OrderMapper.OrderToViewModel(order));
            }
            return View(orderDetailsViewModels);
        }

        public IActionResult Details(int? id)
        {
            ViewBag.User = StaticDb.Users.First();
            ViewBag.Title = "Order Details";
            if(id == null)
            {
                return new EmptyResult();
            }
            Orders order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return new EmptyResult();
            }
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToViewModel(order);

            return View(orderDetailsViewModel);
        }
    }
}
