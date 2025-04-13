
# Week8Day1Task - User & Order Management API

This is a simple ASP.NET Core Web API project for managing **Users** and their associated **Orders**. It includes full CRUD operations and unit tests using **Moq** and **NUnit**.

## 🛠️ Tech Tools

- ASP.NET Core Web API
- Entity Framework Core
- MySQL (via AppDbContext)
- Moq (for mocking dependencies)
- NUnit (for unit testing)

---

## 📁 Project Structure

```
Week8Day1Task/
│
├── Controllers/
│   ├── UserController.cs
│   └── OrderController.cs
│
├── Models/
│   ├── User.cs
│   └── Order.cs
│
├── Repository/
│   ├── IUserRepository.cs
│   └── IOrderRepository.cs
│
├── Services/
│   ├── UserServices.cs
│   └── OrderServices.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Tests/
│   └── Week8Day1TaskTest/
│       ├── UserTest.cs
│       └── OrderTest.cs
```

---

## 🚀 Features

- ✅ CRUD APIs for User
- ✅ CRUD APIs for Order
- ✅ Unit tests for both User and Order controllers
- ✅ Mocking with Moq
- ✅ Repository pattern for separation of concerns

---

## ▶️ How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/Razan-Alahmadi/week8Day1.git
   ```

2. Update your **connection string** in `appsettings.json`.

3. Apply migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. Run the API:
   ```bash
   dotnet run
   ```

---

## ✅ Run Unit Tests

Navigate to the test project folder:

```bash
cd Week8Day1TaskTest
dotnet test
```
---

## 🧪 Unit Test Coverage

### ✅ UserController Tests

- Get all users
- Get user by ID
- Add a new user
- Update a user
- Delete a user
- Delete user (user not found - edge case)

### ✅ OrderController Tests

- Get all orders
- Get order by ID
- Add a new order
- Update an order
- Delete an order
- Delete order (order not found - edge case)


---

## 🧪 Sample API Endpoints

### User

- `GET /api/user/userlist`
- `GET /api/user/getUserbyId?Id=1`
- `POST /api/user/addUser`
- `PUT /api/user/updatUser`
- `DELETE /api/user/deleteUser?Id=1`

### Order

- `GET /api/order/orderlist`
- `GET /api/order/getOrderById?Id=1`
- `POST /api/order/addOrder`
- `PUT /api/order/updateOrder`
- `DELETE /api/order/deleteOrder?Id=1`

