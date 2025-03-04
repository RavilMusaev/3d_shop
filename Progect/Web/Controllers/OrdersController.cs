using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
    public class OrdersController : Controller
    {
        private static List<Orders> _orders = new List<Orders>();

        public IActionResult Index()
        {
            return View(_orders);
        }

        public IActionResult Details(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Orders order)
        {
            if (ModelState.IsValid)
            {
                order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;
                _orders.Add(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id, Orders order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder == null) return NotFound();

            existingOrder.Id_user = order.Id_user;
            existingOrder.Final_sum = order.Final_sum;
            existingOrder.Status_orders = order.Status_orders;
            existingOrder.Date_order = order.Date_order;
            existingOrder.Date_end = order.Date_end;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
            }
            return RedirectToAction("Index");
        }
    }
}

