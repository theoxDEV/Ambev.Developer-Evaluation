# 🧪 Developer Evaluation Project — Sales API

This project is part of a technical assessment and consists of building a complete **Sales API** using:

- **ASP.NET Core 8**
- **DDD (Domain-Driven Design)**
- **CQRS (Command and Query Responsibility Segregation)**
- **EF Core + PostgreSQL**
- **Docker Compose**
- **Unit Testing with xUnit + Moq**

---

## 📦 Features

The API supports full **CRUD operations for sales** and includes:

- ✅ Sale number and date  
- ✅ Customer and branch (external IDs + denormalized names)  
- ✅ Product list with quantity, unit price, discounts, and item totals  
- ✅ Total sale amount  
- ✅ Sale cancellation  
- ✅ Sale item cancellation  
- ✅ Event logs (SaleCreated, SaleCancelled, ItemCancelled)  
- ✅ Validation rules and business logic  
- ✅ Unit tests with full coverage  

---

## ⚙️ Business Rules

- 4 or more identical items → **10% discount**  
- 10 to 20 identical items → **20% discount**  
- More than 20 identical items → ❌ Not allowed  
- Less than 4 items → ❌ No discount  

> These rules are applied at the domain layer (`Sale.AddItem(...)`).

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Docker + Docker Compose](https://www.docker.com/)
- A REST client (e.g. Postman or curl)

---

### ▶️ Running the project

⚠️ Ensure Docker Desktop is running before going forward to these following steps.

⚙️ Use docker-compose as Startup Project and run the project.

Use the following command in the Package Manager Console, using ORM project as Default project:

```bash
dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM --startup-project src/Ambev.DeveloperEvaluation.WebApi
```

This command will:

```
🗂 Create or update the database schema based on the latest entity configurations and migrations in the ORM project.

🧱 Create tables and relationships such as Sales and SaleItems, including keys and constraints.

🌱 Seed initial data using HasData(...) defined in seed methods like:

modelBuilder.Seed();

modelBuilder.SeedBusinessRuleExamples();

⚠️ Ensure Docker is running and the database container is available before executing this command.
```

---

### 🌐 Swagger UI

Once running, access:

```
https://localhost:8081/swagger
```

> Use Swagger to test the endpoints and view schema documentation.

---

## 🧪 Running Tests

To run all unit tests:

⚙️ Use the below command at "../Tests/Unit/Ambev.DeveloperEvaluation.Unit" project path.
```bash
dotnet test
```

Unit tests cover:

- CreateSaleHandler  
- UpdateSaleHandler  
- DeleteSaleHandler  
- CancelSaleHandler  
- GetSaleByIdHandler  
- GetAllSalesHandler  
- Business rule validations  

---

## 🗃️ Project Structure

```
src/
├── WebApi               → Controllers, Dependency Injection
├── Application          → Commands, Queries, Handlers, Validators, Responses
├── Domain               → Entities, Repositories, Business Rules
├── ORM                  → DbContext, Entity Mappings, Migrations

tests/
└── Tests.Unit           → xUnit tests organized by use case
```

---

## 🧾 Sample Payloads

### ➕ Create Sale (POST /api/sales)

```json
{
  "customerId": "11111111-1111-1111-1111-111111111111",
  "customerName": "Customer A",
  "branchId": "22222222-2222-2222-2222-222222222222",
  "branchName": "Main Branch",
  "items": [
    {
      "description": "Mouse Gamer",
      "quantity": 5,
      "price": 100
    }
  ]
}
```

> ✅ Expected discount: 10%  
> 💰 Total: `5 x 100 x 0.9 = 450`

---

### ➕ Create INVALID Sale (POST /api/sales)

```json
{
  "customerId": "00000000-0000-0000-0000-000000000000",
  "customerName": "",
  "branchId": "00000000-0000-0000-0000-000000000000",
  "branchName": "",
  "items": [
    {
      "description": "TV",
      "quantity": 25,
      "price": -100
    },
    {
      "description": "",
      "quantity": 0,
      "price": 0
    }
  ]
}
```

## 📝 Notes

- Discounts are **automatically calculated** in the domain layer.  
- The client does **not** send discounts manually.  
- Sale numbers are auto-generated as `SALE-XXXXXXX`.  
- Items with quantity > 20 throw a validation error.  
- Items with quantity < 4 receive no discount.

---

## 👨‍💻 Author: Matheus Nascimento
Feel free to reach out for questions or feedback.
