# 🏢 Company System - HR Management Backend API

An advanced Human Resource Management System built using **ASP.NET Core Web API**, designed to handle employees, departments, projects, payroll, and attendance in an enterprise-level organization.

---

## 🚀 Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* AutoMapper
* JWT Authentication
* .NET Identity

---

## 🧱 Architecture & Design Patterns

* Clean Architecture
* Repository Pattern
* Unit of Work
* Modular Service-Oriented Structure

---

## ✨ Core Features

* 👥 Employees & Departments CRUD
* 🗂️ Project Management with Department linkage
* 📆 Attendance System with CheckIn/CheckOut
* 💰 Payroll Generation with Salary Calculation
* 🔐 Secure Authentication with JWT
* 📄 Error Handling & Validation
* 🔎 Search, Pagination, Sorting for Employees

---

## 📁 Project Structure

```
/Company.API         → Main API project (Controllers, Middleware, Startup)
/Company.Core        → Core domain (Entities, Interfaces, Specifications)
/Company.Repository  → Database layer (DbContext, Repositories)
/Company.Service     → Business Logic
```

---

## ⚙️ Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/mohamedabuelmgd/company-system.git
```

### 2. Configure the connection string

* Update `appsettings.json` with your local SQL Server credentials

### 3. Apply database migrations

```bash
dotnet ef database update
```

### 4. Run the project

```bash
dotnet run
```

---

## 📳 API Testing (Postman)

👉 [Download Postman Collection](./postman/company%20collection.postman_collection.json)

### Steps:

1. Open **Postman**
2. Click **Import**
3. Upload `company collection.postman_collection.json`
4. Make sure to set the variable `BaseUrl` to your local server (e.g. `https://localhost:5001`)

---

## 👨‍💻 Developed By

**Mohamed Saeed Abuelmgd**
[LinkedIn](https://www.linkedin.com/in/mohamed-abuelmgd-519528237/)
[GitHub](https://github.com/mohamedabuelmgd)
