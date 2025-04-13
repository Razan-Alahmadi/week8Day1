using Week8Day1Task.Models;

namespace Week8Day1Task.Repository
{
    public interface IOrderRepository
    {
        // CRUD operations for Order
        // GetAll, 
        IEnumerable<Order> GetAll();

        //GetById
        Order GetById(int id);

        //Add
        Order Add(Order order);
        //Update
        Order Update(Order order);

        //Delete
        bool Delete(int id);
    }
}
