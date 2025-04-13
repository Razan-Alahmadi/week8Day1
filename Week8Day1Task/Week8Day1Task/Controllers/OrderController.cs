using Microsoft.AspNetCore.Mvc;
using Week8Day1Task.Models;
using Week8Day1Task.Repository;

namespace Week8Day1Task.Controllers
{
    public class OrderController
    {
        private readonly IOrderRepository orderService;

        public OrderController(IOrderRepository _orderService)
        {
            orderService = _orderService;
        }

        //----------------------------------------------

        [HttpGet("orderlist")]
        public IEnumerable<Order> OrderList()
        {
            var orderList = orderService.GetAll();
            return orderList;
        }

        [HttpGet("getOrderById")]
        public Order GetOrderById(int Id)
        {
            return orderService.GetById(Id);
        }

        [HttpPost("addOrder")]
        public Order AddOrder(Order order)
        {
            return orderService.Add(order);
        }

        [HttpPut("updateOrder")]
        public Order UpdateOrder(Order order)
        {
            return orderService.Update(order);
        }

        [HttpDelete("deleteOrder")]
        public bool DeleteOrder(int Id)
        {
            return orderService.Delete(Id);
        }
    }
}
