# Employee Management API  

## Overview  

The **Employee Management API** is a RESTful API built with **.NET 9**, following modern best practices such as **SOLID principles**, **Entity Framework Core**, and **JWT authentication**. It allows users to perform **CRUD (Create, Read, Update, Delete)** operations on employee records securely.  

## Features  

✅ Employee CRUD operations  
✅ JWT-based authentication  
✅ Entity Framework Core for database interactions  
✅ SOLID and OOP principles  
✅ Swagger API documentation  

---  

## 🛠 Tech Stack  

- **.NET 9 Web API**  
- **Entity Framework Core** (SQL Server)  
- **JWT Authentication**  
- **Swagger (OpenAPI)**  

---  

## 📂 Project Structure  

```
Employee_Management/
│-- Controllers/               # API Controllers
│   ├── AuthController.cs      # Handles authentication (login, token generation)
│   ├── EmployeesController.cs # Handles employee CRUD operations
│
│-- DataAccess/                # Database context and configurations
│-- DTOs/                      # Data Transfer Objects (optional but recommended)
│-- Entities/                  # Database entity models
│-- Migrations/                # EF Core Migrations
│-- Repositories/              # Data access layer
│-- Services/                  # Business logic layer
│   ├── EmployeeService.cs
│   ├── IEmployeeService.cs
│
│-- appsettings.json           # App configuration (DB connection, JWT settings)
│-- Program.cs                 # Entry point of the application
```  

---  

## 🚀 Getting Started  

### 1️⃣ Prerequisites  

- .NET 9 SDK  
- SQL Server (or SQLite for development)  

### 2️⃣ Setup & Configuration  

1. Clone the repository:  
   ```sh
   git clone https://github.com/your-repo/employee-management.git
   cd employee-management
   ```
2. Update **appsettings.json** with your SQL Server connection string and JWT settings.  
3. Run database migrations:  
   ```sh
   dotnet ef database update
   ```
4. Run the API:  
   ```sh
   dotnet run
   ```

---  

## 🔄 API Endpoints & Responses  

### 🔹 Authentication  

**Login (Get JWT Token)**  

```
POST /api/auth/login
```  

**Request:**  

```json
{
  "username": "admin",
  "password": "password123"
}
```  

**Response:**  

```json
{
  "token": "eyJhbGciOiJIUzI1..."
}
```  

### 🔹 Employees CRUD  

**1️⃣ Get All Employees**  

```
GET /api/employees
```  

**Response:**  

```json
{
  "status": "success",
  "data": [
    {
      "id": 1,
      "firstName": "Amit",
      "lastName": "Sharma",
      "email": "amit.sharma@example.com",
      "position": "Software Engineer",
      "salary": 70000
    }
  ]
}
```  

**2️⃣ Get Employee by ID**  

```
GET /api/employees/{id}
```  

**Response:**  

```json
{
  "status": "success",
  "data": {
    "id": 1,
    "firstName": "Amit",
    "lastName": "Sharma",
    "email": "amit.sharma@example.com",
    "position": "Software Engineer",
    "salary": 70000
  }
}
```  

**3️⃣ Create Employee**  

```
POST /api/employees
```  

**Request:**  

```json
{
  "firstName": "Priya",
  "lastName": "Verma",
  "email": "priya.verma@example.com",
  "dateOfBirth": "1995-04-15",
  "position": "Manager",
  "salary": 90000
}
```  

**Response:**  

```json
{
  "status": "success",
  "message": "Employee created successfully",
  "data": {
    "id": 2,
    "firstName": "Priya",
    "lastName": "Verma",
    "email": "priya.verma@example.com",
    "position": "Manager",
    "salary": 90000
  }
}
```  

**4️⃣ Update Employee**  

```
PUT /api/employees/{id}
```  

**Request:**  

```json
{
  "firstName": "Priya",
  "lastName": "Kapoor",
  "position": "Senior Manager",
  "salary": 95000
}
```  

**Response:**  

```json
{
  "status": "success",
  "message": "Employee updated successfully",
  "data": {
    "id": 2,
    "firstName": "Priya",
    "lastName": "Kapoor",
    "email": "priya.verma@example.com",
    "position": "Senior Manager",
    "salary": 95000
  }
}
```  

**5️⃣ Delete Employee**  

```
DELETE /api/employees/{id}
```  

**Response:**  

```json
{
  "status": "success",
  "message": "Employee deleted successfully"
}
```  

---  

## 🔐 Authentication & Security  

- Uses **JWT Authentication**.  
- Requires a valid **Bearer Token** for accessing employee CRUD endpoints.  
- Tokens expire after a set period (configurable in `appsettings.json`).  

---  

## 📜 API Documentation  

Swagger is enabled for API testing.  

- Visit: `https://localhost:5001/swagger`  
- Allows testing endpoints directly from the browser.  
- If you are familiar with **Postman**, you can also use it to test API endpoints easily.  

---  

## 🤝 Contribution Guidelines  

1. Fork the repository  
2. Create a new branch (`feature-xyz`)  
3. Commit changes and push to the branch  
4. Open a Pull Request 🚀  
