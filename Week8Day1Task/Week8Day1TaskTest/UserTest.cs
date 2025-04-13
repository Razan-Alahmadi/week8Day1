using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Day1Task.Models;
using Week8Day1Task.Repository;
using Week8Day1Task.Services;
using Moq;
using Week8Day1Task.Controllers;

namespace Week8Day1TaskTest
{
    internal class UserTest
    {

        private Mock<IUserRepository> _userServiceMock;
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserRepository>();
            _userController = new UserController(_userServiceMock.Object);
        }

        //-------------------------------------------------------------------------
        // Test CRUD operations for User
        // 1- GetAll
        [Test]
        public void GetUser_UserList()
        {
            // Arrange
            var userList = GetMockUsersData();
            _userServiceMock.Setup(x => x.GetAll())
                .Returns(userList);

            // Act
            var result = _userController.UserList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(userList.Count));
            Assert.That(result, Is.EquivalentTo(userList));
        }


        // 2- GetById
        [Test]
        public void GetUserByID_User()
        {
            // Arrange
            var userList = GetMockUsersData();
            _userServiceMock.Setup(x => x.GetById(2)) // get from service
                .Returns(userList[1]);

            // Act
            var Result = _userController.GetUserById(2); // get from controller

            // Assert
            Assert.That(Result, Is.Not.Null);
            Assert.That(Result.Id, Is.EqualTo(userList[1].Id));
        }


        // 3- Add
        [Test]
        public void AddUser_User()
        {
            // Arrange
            var userList = GetMockUsersData();
            _userServiceMock.Setup(x => x.Add(userList[1]))
                .Returns(userList[1]);

            // Act
            var Result = _userController.AddUser(userList[1]);

            // Assert
            Assert.That(Result, Is.Not.Null);
            Assert.That(Result.Id, Is.EqualTo(userList[1].Id));
        }

        // 4- Update
        [Test]
        public void UpdateUser_UserUpdated()
        {
            // Arrange
            var userList = GetMockUsersData();
            var updatedUser = new User
            {
                Id = 2,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                Email = "updated@example.com",
                Orders = new List<Order>()
            };

            _userServiceMock.Setup(x => x.Update(updatedUser)).Returns(updatedUser);

            // Act
            var result = _userController.UpdateUser(updatedUser);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("UpdatedFirstName"));
            Assert.That(result.LastName, Is.EqualTo("UpdatedLastName"));
            Assert.That(result.Email, Is.EqualTo("updated@example.com"));
        }

        // 5- Delete
        [Test]
        public void DeleteUser_UserDeleted()
        {
            // Arrange
            var userId = 2;
            _userServiceMock.Setup(x => x.Delete(userId)).Returns(true);

            // Act
            var result = _userController.DeleteUser(userId);

            // Assert
            Assert.That(result, Is.True);
        }

        // 6- Delete User Not Found (edge cases)
        [Test]
        public void DeleteUser_UserNotFound()
        {
            // Arrange
            var nonExistentUserId = 999; // Assuming this user doesn't exist
            _userServiceMock.Setup(x => x.Delete(nonExistentUserId)).Returns(false);

            // Act
            var result = _userController.DeleteUser(nonExistentUserId);

            // Assert
            Assert.That(result, Is.False);
        }


        private List<User> GetMockUsersData()
        {
            return new List<User>
    {
        new User
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Smith",
            Email = "alice@example.com",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderId = 101,
                    Product = "Laptop",
                    Quantity = 1,
                    Price = 50000,
                    UserId = 1
                },
                new Order
                {
                    OrderId = 102,
                    Product = "Mouse",
                    Quantity = 2,
                    Price = 2000,
                    UserId = 1
                }
            }
        },
        new User
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Jones",
            Email = "bob@example.com",
            Orders = new List<Order>
            {
                new Order
                {
                    OrderId = 201,
                    Product = "Keyboard",
                    Quantity = 1,
                    Price = 3000,
                    UserId = 2
                }
            }
        }
    };
        }



    }
}
