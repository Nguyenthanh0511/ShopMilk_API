# ShopMilk_API

## Overview
ShopMilk_API is a RESTful API service for managing a milk shop's operations, including inventory, sales, customer management, and ordering systems. This project is based on the work by Hieu k15 and has been extended to include both backend API development and a frontend implementation (FE_ShopMilk).

## Project Reference
This project is developed with reference to Hieu k15's original work. The current implementation:
- Extends the backend API functionality
- Adds a complementary frontend application (FE_ShopMilk)
- Implements the Repository Pattern for improved data access architecture

## Features
- Product management (add, update, delete milk products)
- Inventory tracking and stock management
- Order processing and history
- Customer account management
- Sales analytics
- Payment integration

## Tech Stack
### Backend (ShopMilk_API)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server/MySQL (database)
- JWT Authentication
- Swagger UI for API documentation
- Repository Pattern for data access

### Frontend (FE_ShopMilk)
- [Frontend framework - e.g., React, Angular, Vue.js]
- [State management - if applicable]
- [UI libraries]
- RESTful API integration with ShopMilk_API

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- SQL Server/MySQL database
- Visual Studio 2022 or Visual Studio Code
- [Node.js and npm - for frontend]

### Installation

#### Backend (ShopMilk_API)
1. Clone the repository:
```
git clone https://github.com/Nguyenthanh0511/ShopMilk_API.git
```

2. Navigate to the project directory:
```
cd ShopMilk_API
```

3. Update the database connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ShopMilk;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

4. Run the database migrations:
```
dotnet ef database update
```

5. Run the application:
```
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`.

#### Frontend (FE_ShopMilk)
1. Clone the frontend repository:
```
git clone [FE_ShopMilk repository URL]
```

2. Navigate to the frontend project directory:
```
cd FE_ShopMilk
```

3. Install dependencies:
```
npm install
```

4. Configure the API endpoint in the frontend environment files to point to your running API instance.

5. Start the frontend application:
```
npm start
```

The frontend will be available at `http://localhost:3000` (or another port depending on your configuration).

## Project Structure

### Backend Structure (ShopMilk_API)
```
ShopMilk_API/
├── Controllers/              # API controllers
├── Models/                   # Data models and DTOs
│   ├── Entities/             # Database entities
│   └── DTOs/                 # Data Transfer Objects
├── Repositories/             # Repository pattern implementation
│   ├── Interfaces/           # Repository interfaces
│   │   ├── IRepository.cs    # Generic repository interface
│   │   ├── IProductRepository.cs
│   │   ├── IOrderRepository.cs
│   │   └── ...
│   └── Implementations/      # Repository implementations
│       ├── Repository.cs     # Generic repository implementation
│       ├── ProductRepository.cs
│       ├── OrderRepository.cs
│       └── ...
├── Services/                 # Business logic services
│   ├── Interfaces/           # Service interfaces
│   └── Implementations/      # Service implementations
├── Data/                     # Database context
│   ├── ApplicationDbContext.cs
│   └── Configurations/       # Entity configurations
├── Migrations/               # Database migrations
├── Helpers/                  # Helper classes and extensions
├── Middleware/               # Custom middleware
├── Configurations/           # App configuration
└── Program.cs                # Application entry point
```

### Frontend Structure (FE_ShopMilk)
```
FE_ShopMilk/
├── public/                   # Static files
├── src/                      # Source files
│   ├── components/           # Reusable components
│   ├── pages/                # Application pages
│   ├── services/             # API services
│   ├── store/                # State management
│   ├── utils/                # Utility functions
│   ├── assets/               # Images, fonts, etc.
│   ├── App.js                # Main application component
│   └── index.js              # Application entry point
├── package.json              # Dependencies and scripts
└── README.md                 # Frontend documentation
```

## Repository Pattern Implementation

The project uses the Repository pattern to abstract the data access layer:

### Core Interfaces
- `IRepository<T>` - Generic repository interface with CRUD operations
- Entity-specific repositories (e.g., `IProductRepository`, `IOrderRepository`)

### Repository Registration in Startup

```csharp
// In Program.cs or Startup.cs
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
// Register other repositories
```

### Example Repository Implementation

```csharp
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}
```

## API Endpoints

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product

### Orders
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID
- `POST /api/orders` - Create a new order
- `PUT /api/orders/{id}` - Update an order
- `DELETE /api/orders/{id}` - Delete an order

### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Register a new customer
- `PUT /api/customers/{id}` - Update customer information
- `DELETE /api/customers/{id}` - Delete a customer

## Authentication
The API uses JWT Bearer token authentication. To access protected endpoints:

1. Register a user or login to get a token
2. Include the token in the Authorization header:
```
Authorization: Bearer {your_token}
```

## Documentation
API documentation is available via Swagger UI at `/swagger` when running the application.

## Development

### Running Tests
```
dotnet test
```

## Deployment
Instructions for deploying to:
- Azure App Service
- Docker container
- IIS Server

## Contributing
1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments
- I reference project by Hieu k15
- All contributors to the ShopMilk_API project and others ( Increase code backend )

## Contact
- Developer: [Your Name]
- Email: [Your Email]
- Project Link: https://github.com/Nguyenthanh0511/ShopMilk_API
- Frontend Repository: [https://github.com/Nguyenthanh0511/FE_Shopmilk]
