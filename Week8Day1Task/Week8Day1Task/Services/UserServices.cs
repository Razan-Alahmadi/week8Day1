using System.Linq;
using Week8Day1Task.Data;
using Week8Day1Task.Repository;
using Week8Day1Task.Models;
namespace Week8Day1Task.Services
{
    public class UserServices: IUserRepository
    {

        private readonly AppDbContext _dbContext;
        public UserServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implement IUserRepository Functions 

        //1- GatUsers
        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        //2-GetById
        public User GetById(int Id) {
            return _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
        }

        //3- Add
        public User Add(User user)
        {
            var result =_dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        //4- update
        public User Update(User user)
        {
            var result = _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        //5- delete
        public bool Delete(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

    }
}
