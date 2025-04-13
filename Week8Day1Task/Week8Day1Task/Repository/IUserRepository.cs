using Week8Day1Task.Models;

namespace Week8Day1Task.Repository
{
    public interface IUserRepository
    {

        // CRUD operations for User
        // GetAll, 
        IEnumerable<User> GetAll();
        //GetById
        User GetById(int id);
        //Add
        User Add(User user);
        //Update
        User Update(User user);
        //Delete
        bool Delete(int id);
    }
}
