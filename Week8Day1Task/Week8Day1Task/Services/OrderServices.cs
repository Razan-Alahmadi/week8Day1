using Week8Day1Task.Data;
using Week8Day1Task.Models;
using Week8Day1Task.Repository;

namespace Week8Day1Task.Services
{
    public class OrderServices: IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implement IUserRepository Functions 

        //1- GetAll
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        //2-GetById
        public Order GetById(int Id)
        {
            return _dbContext.Orders.Where(x => x.OrderId == Id).FirstOrDefault();
        }

        //3- Add
        public Order Add(Order order)
        {
            var result = _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        //4- update
        public Order Update(Order order)
        {
            var result = _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        //5- delete
        public bool Delete(int Id)
        {
            var filteredData = _dbContext.Orders.Where(x => x.OrderId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
