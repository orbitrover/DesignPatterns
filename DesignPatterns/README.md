# Design Patterns Practice in Asp Net Core 8.0 C# (GoF) design patterns





<p>Creating an ASP.NET Core 8 Web API for an e-commerce project that demonstrates all the design patterns mentioned is quite extensive. Each design pattern will serve a specific purpose in the context of the application, such as managing user accounts, processing orders, interacting with products, etc.</p><p>Let's break down the usage of each pattern in the context of the e-commerce project:</p><h3>Project Overview</h3><p><strong>E-Commerce System</strong>:<br>An online store that allows users to browse products, add them to a cart, place orders, and manage user profiles.</p>
<h4><strong>Creational Patterns</strong></h4>
<ol>
<li><strong>Singleton</strong>:<br>Used for a logging service to ensure only one instance handles all log messages.</li>
<li><strong>Factory Method</strong>:<br>Used for creating different types of payment processors (e.g., Credit Card, PayPal, etc.).</li>
<li><strong>Abstract Factory</strong>:<br>Used to create families of related objects like product variants or order-related objects.</li>
<li><strong>Builder</strong>:<br>Used for constructing complex objects such as Order or User profiles step by step.</li>
<li><strong>Prototype</strong>:<br>Used for creating new instances of an existing product by copying its details.</li>
</ol>
<h4><strong>Structural Patterns</strong></h4>
<ol>
<li><strong>Adapter</strong>:<br>Used to integrate third-party payment gateway APIs that have different interfaces.</li>
<li><strong>Decorator</strong>:<br>Used to add additional features to the product (e.g., adding gift wrapping, express shipping).</li>
<li><strong>Facade</strong>:<br>Used to provide a simplified interface to a complex order processing subsystem.</li>
<li><strong>Composite</strong>:<br>Used to handle categories and subcategories of products as a tree structure.</li>
<li><strong>Proxy</strong>:<br>Used to provide a placeholder for the actual product data, loading it on demand (lazy loading).</li>
</ol>
<h4><strong>Behavioral Patterns</strong></h4>
<ol>
<li><strong>Observer</strong>:<br>Used to notify subscribers (e.g., inventory management system, user notifications) whenever an order is placed.</li>
<li><strong>Strategy</strong>:<br>Used to select different shipping algorithms based on user preferences or geographic location.</li>
<li><strong>Command</strong>:<br>Used to encapsulate requests such as placing an order or processing a payment as objects.</li>
<li><strong>Iterator</strong>:<br>Used to iterate over collections of products, orders, etc., without exposing their underlying structure.</li>
<li><strong>State</strong>:<br>Used to handle the different states of an order (e.g., Created, Paid, Shipped, Delivered).</li>
</ol>
<h3>Code Example Structure</h3>
<p>I will provide a skeleton for each pattern, integrating them into the e-commerce system. Due to the complexity, let's provide a brief code example for each pattern, and you can extend or refine them as needed for your specific requirements.</p>
<h4>1. <strong>Singleton Pattern (Logging Service)</strong></h4>

```csharp
namespace Core.Services.CreationalPatterns.Singleton
{
	public class LogService
	{
		private static LogService _instance;
		private static readonly object _lock = new object();

		private LogService() { }

		public static LogService Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new LogService();
					}
					return _instance;
				}
			}
		}

		public void Log(string message)
		{
			// Log to a file, database, etc.
			Console.WriteLine(message);
		}
	}
}
```

<h4>2. <strong>Factory Method (Payment Processors)</strong></h4>

```csharp
	namespace Core.Services.CreationalPatterns.FactoryMethod
	{
		public abstract class PaymentProcessor
		{
			public abstract void ProcessPayment(decimal amount);
		}

		public class CreditCardProcessor : PaymentProcessor
		{
			public override void ProcessPayment(decimal amount)
			{
				// Implement credit card payment processing
				Console.WriteLine($"Processed credit card payment of {amount}");
			}
		}

		public class PayPalProcessor : PaymentProcessor
		{
			public override void ProcessPayment(decimal amount)
			{
				// Implement PayPal payment processing
				Console.WriteLine($"Processed PayPal payment of {amount}");
			}
		}

		public class PaymentProcessorFactory
		{
			public static PaymentProcessor GetPaymentProcessor(string type)
			{
				switch (type)
				{
					case "CreditCard":
						return new CreditCardProcessor();
					case "PayPal":
						return new PayPalProcessor();
					default:
						throw new ArgumentException("Invalid payment processor type");
				}
			}
		}
	}
```

<h4>3. <strong>Abstract Factory (Order-Related Objects)</strong></h4>

```csharp
	namespace Core.Services.CreationalPatterns.AbstractFactory
	{
		public interface IOrderFactory
		{
			IOrder CreateOrder();
			IShipping CreateShipping();
		}

		public class StandardOrderFactory : IOrderFactory
		{
			public IOrder CreateOrder() => new StandardOrder();
			public IShipping CreateShipping() => new StandardShipping();
		}

		public class PremiumOrderFactory : IOrderFactory
		{
			public IOrder CreateOrder() => new PremiumOrder();
			public IShipping CreateShipping() => new ExpressShipping();
		}
	}
```

<h4>4. <strong>Builder Pattern (Complex Object Creation - Order)</strong></h4>

```csharp
	namespace Core.Services.CreationalPatterns.Builder
	{
		public class OrderBuilder
		{
			private Order _order = new Order();

			public OrderBuilder AddProduct(Product product)
			{
				_order.Products.Add(product);
				return this;
			}

			public OrderBuilder SetCustomer(Customer customer)
			{
				_order.Customer = customer;
				return this;
			}

			public OrderBuilder SetShippingAddress(string address)
			{
				_order.ShippingAddress = address;
				return this;
			}

			public Order Build()
			{
				return _order;
			}
		}
	}
```

<h4>5. <strong>Prototype Pattern (Product Cloning)</strong></h4>

```csharp
	namespace Core.Services.CreationalPatterns.Prototype
	{
		public abstract class ProductPrototype
		{
			public abstract ProductPrototype Clone();
		}

		public class Product : ProductPrototype
		{
			public string Name { get; set; }
			public decimal Price { get; set; }

			public override ProductPrototype Clone()
			{
				return (ProductPrototype)this.MemberwiseClone();
			}
		}
	}
```

<h4>6. <strong>Adapter Pattern (Third-Party Payment Gateway)</strong></h4>

```csharp
	namespace Core.Services.StructuralPatterns.Adapter
	{
		public interface IPaymentGateway
		{
			void MakePayment(decimal amount);
		}

		public class ThirdPartyPaymentService
		{
			public void Pay(decimal amount)
			{
				// Payment processing
				Console.WriteLine($"Paid {amount} using third-party service");
			}
		}

		public class PaymentGatewayAdapter : IPaymentGateway
		{
			private readonly ThirdPartyPaymentService _thirdPartyPaymentService;

			public PaymentGatewayAdapter(ThirdPartyPaymentService thirdPartyPaymentService)
			{
				_thirdPartyPaymentService = thirdPartyPaymentService;
			}

			public void MakePayment(decimal amount)
			{
				_thirdPartyPaymentService.Pay(amount);
			}
		}
	}
```

<h4>7. <strong>Decorator Pattern (Additional Product Features)</strong></h4>

```csharp
	namespace Core.Services.StructuralPatterns.Decorator
	{
		public interface IProduct
		{
			string GetDescription();
			decimal GetPrice();
		}

		public class BasicProduct : IProduct
		{
			public string GetDescription() => "Basic Product";
			public decimal GetPrice() => 50;
		}

		public class GiftWrapDecorator : IProduct
		{
			private readonly IProduct _product;

			public GiftWrapDecorator(IProduct product)
			{
				_product = product;
			}

			public string GetDescription() => _product.GetDescription() + ", Gift Wrapped";
			public decimal GetPrice() => _product.GetPrice() + 5;
		}
	}
```

<h4>8. <strong>Facade Pattern (Order Processing Subsystem)</strong></h4>

```csharp
	namespace Core.Services.StructuralPatterns.Facade
	{
		public class OrderFacade
		{
			private readonly OrderService _orderService;
			private readonly PaymentService _paymentService;
			private readonly ShippingService _shippingService;

			public OrderFacade()
			{
				_orderService = new OrderService();
				_paymentService = new PaymentService();
				_shippingService = new ShippingService();
			}

			public void PlaceOrder(Order order, PaymentDetails paymentDetails)
			{
				_orderService.ProcessOrder(order);
				_paymentService.ProcessPayment(paymentDetails);
				_shippingService.ShipOrder(order);
			}
		}
	}
```

<h4>9. <strong>Composite Pattern (Category Hierarchy)</strong></h4>

```csharp
	namespace Core.Services.StructuralPatterns.Composite
	{
		public interface ICategoryComponent
		{
			void Display();
		}

		public class Category : ICategoryComponent
		{
			public string Name { get; set; }
			private readonly List<ICategoryComponent> _subCategories = new List<ICategoryComponent>();

			public void Add(ICategoryComponent category) => _subCategories.Add(category);
			public void Remove(ICategoryComponent category) => _subCategories.Remove(category);
			
			public void Display()
			{
				Console.WriteLine($"Category: {Name}");
				foreach (var subCategory in _subCategories)
				{
					subCategory.Display();
				}
			}
		}
	}
```

<h4>10. <strong>Proxy Pattern (Lazy Loading of Product Data)</strong></h4>

```csharp
	namespace Core.Services.StructuralPatterns.Proxy
	{
		public interface IProductData
		{
			string GetProductDetails();
		}

		public class RealProductData : IProductData
		{
			private string _productDetails;

			public RealProductData()
			{
				// Simulate expensive operation
				_productDetails = "Detailed product information";
			}

			public string GetProductDetails() => _productDetails;
		}

		public class ProductDataProxy : IProductData
		{
			private RealProductData _realProductData;
			
			public string GetProductDetails()
			{
				if (_realProductData == null)
				{
					_realProductData = new RealProductData();
				}
				return _realProductData.GetProductDetails();
			}
		}
	}
```


<h4>11. <strong>Observer Pattern (Order Event Notification)</strong></h4>

```csharp
	namespace Core.Services.BehavioralPatterns.Observer
	{
		public interface IObserver
		{
			void Update(Order order);
		}

		public class InventoryObserver : IObserver
		{
			public void Update(Order order)
			{
				// Update inventory
				Console.WriteLine("Inventory updated for order: " + order.Id);
			}
		}

		public class EmailNotificationObserver : IObserver
		{
			public void Update(Order order)
			{
				// Send email notification
				Console.WriteLine("Email sent for order: " + order.Id);
			}
		}

		public class OrderSubject
		{
			private readonly List<IObserver> _observers = new List<IObserver>();

			public void Attach(IObserver observer) => _observers.Add(observer);
			public void Detach(IObserver observer) => _observers.Remove(observer);

			public void Notify(Order order)
			{
				foreach (var observer in _observers)
				{
					observer.Update(order);
				}
			}
		}
	}
```

<h4>12. <strong>Strategy Pattern (Shipping Cost Calculation)</strong></h4>

```csharp
	namespace Core.Services.BehavioralPatterns.Strategy
	{
		public interface IShippingStrategy
		{
			decimal CalculateShippingCost(Order order);
		}

		public class StandardShippingStrategy : IShippingStrategy
		{
			public decimal CalculateShippingCost(Order order)
			{
				return 10; // Flat rate
			}
		}

		public class ExpressShippingStrategy : IShippingStrategy
		{
			public decimal CalculateShippingCost(Order order)
			{
				return 25; // Flat rate for express shipping
			}
		}
	}
```

<h4>13. <strong>Command Pattern (Encapsulate Orders)</strong></h4>

```csharp
	namespace Core.Services.BehavioralPatterns.Command
	{
		public interface ICommand
		{
			void Execute();
		}

		public class PlaceOrderCommand : ICommand
		{
			private readonly Order _order;

			public PlaceOrderCommand(Order order)
			{
				_order = order;
			}

			public void Execute()
			{
				// Logic to place the order
				Console.WriteLine($"Order {_order.Id} placed.");
			}
		}

		public class CancelOrderCommand : ICommand
		{
			private readonly Order _order;

			public CancelOrderCommand(Order order)
			{
				_order = order;
			}

			public void Execute()
			{
				// Logic to cancel the order
				Console.WriteLine($"Order {_order.Id} cancelled.");
			}
		}
	}
```

<h4>14. <strong>Iterator Pattern (Product Collection Iteration)</strong></h4>

```csharp
	namespace Core.Services.BehavioralPatterns.Iterator
	{
		public interface IIterator
		{
			bool HasNext();
			Product Next();
		}

		public class ProductIterator : IIterator
		{
			private readonly List<Product> _products;
			private int _position = 0;

			public ProductIterator(List<Product> products)
			{
				_products = products;
			}

			public bool HasNext() => _position < _products.Count;

			public Product Next() => _products[_position++];
		}
	}
```

<h4>15. <strong>State Pattern (Order State Management)</strong></h4>

```csharp
	namespace Core.Services.BehavioralPatterns.State
	{
		public interface IOrderState
		{
			void Handle(Order order);
		}

		public class OrderCreatedState : IOrderState
		{
			public void Handle(Order order)
			{
				// Handle created state
				Console.WriteLine($"Order {order.Id} is in created state.");
				order.SetState(new OrderPaidState());
			}
		}

		public class OrderPaidState : IOrderState
		{
			public void Handle(Order order)
			{
				// Handle paid state
				Console.WriteLine($"Order {order.Id} is paid.");
				order.SetState(new OrderShippedState());
			}
		}

		public class OrderShippedState : IOrderState
		{
			public void Handle(Order order)
			{
				// Handle shipped state
				Console.WriteLine($"Order {order.Id} is shipped.");
				order.SetState(new OrderDeliveredState());
			}
		}
	}
```

<h3>Putting It All Together</h3>

<p>Creating a complete e-commerce Web API using ASP.NET Core 8 that demonstrates all the design patterns is a comprehensive task. To help you with this, I'll provide a more complete example including controllers, <code>Program.cs</code>, view models, <code>ApplicationDbContext</code>, and JWT authentication setup.</p>
<h3>Project Structure</h3>
<p>Here is a breakdown of the components we'll include:</p>
<ol>
<li><strong><code>Program.cs</code></strong>: Entry point for the ASP.NET Core application.</li>
<li><strong>Controllers</strong>: To handle HTTP requests and interact with services.</li>
<li><strong>Models</strong>: Define the data structures (e.g., <code>Product</code>, <code>Order</code>, <code>User</code>).</li>
<li><strong>ViewModels</strong>: For managing input/output from the API.</li>
<li><strong>ApplicationDbContext</strong>: Entity Framework Core context for database interaction.</li>
<li><strong>JWT Authentication</strong>: For securing the API endpoints.</li>
<li><strong>Services and Patterns Implementation</strong>: Core business logic and design pattern implementations.</li>
</ol>
<h3>1. <code>Program.cs</code></h3>

```csharp
using Core.Services.CreationalPatterns.Singleton;
using Core.Services.Implementation;
using Core.Services.Interfaces;
using System.Text;
using Core.Repo.Data;
using Core.Repo.Interface;
using Core.Repo.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add ApplicationDbContext with In-Memory Database for simplicity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ECommerceDb"));

// Configure JWT Authentication
var key = Encoding.ASCII.GetBytes("YourJWTSecretKey12345!");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Register Services
builder.Services.AddSingleton<ILogService, LogService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
// Register Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

```

<h3>2. <strong>Models</strong></h3>
<h4><code>Product.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int LockedQty { get; set; }
    }
}

```

<h4><code>Order.cs</code></h4>

```csharp
using Core.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }

        public void SetState(IOrderState state)
        {
            state.Handle(this);
        }
    }
}

```


<h4><code>OrderItem.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TaxPercentage { get; set; }
        public double Cost { get; set; }
        public decimal Price { get; set; }
    }
}

```

<h4><code>ShoppingCart.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public bool IsOrdered { get; set; }
    }
}

```

<h4><code>CartItem.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TaxPercentage { get; set; }
        public double Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsOrdered { get; set; }
    }
}

```

<h4><code>ShippingAddress.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;
using Core.Data.Enums;

namespace Core.Data
{
    public class ShippingAddress
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string AddressDetails { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public bool IsDefaultAddress { get; set; }
        public AddressType addressType { get; set; }
    }
    
}

```

<h4><code>User.cs</code></h4>

```csharp
namespace Core.Data
{
	public class User
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }  // Note: Store securely with hashing in production
		public string Role { get; set; }
	}
}
```


<h4><code>PaymentDetails.cs</code></h4>

```csharp
using System.ComponentModel.DataAnnotations;

namespace Core.Data
{
    public class PaymentDetails
    {
        [Key]
        public string Id { get; set; }
    }
}

```

<h4><code>ResponseModel.cs</code></h4>

```csharp
namespace Core.Data
{
	public class ResponseModel
	{
		public int ResponseCode { get; set; }
		public string ResponseMessage { get; set; }
		public string ResponseData { get; set; }
	}
}
```

<h3>2a. <strong>Enums</strong></h3>
<h4><code>OrderStatus.cs</code></h4>

```csharp
namespace Core.Data.Enums
{
	public enum OrderStatus
	{
		Created,
		Paid,
		Shipped,
		Delivered,
		Cancelled
	}
	public enum AddressType
	{
		Home,
		Office,
		Other
	}
}
```

<h3>3. <strong>ViewModels</strong></h3>
<h4><code>UserViewModel.cs</code></h4>

```csharp
public class UserViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

```

<h4><code>OrderViewModel.cs</code></h4>

```csharp
namespace Core.Data.ViewModel
{
	public class OrderViewModel
	{
		public List<OrderItemViewModel> Items { get; set; }
		public decimal TotalAmount { get; set; }
	}

	public class OrderItemViewModel
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}

    public class UserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
```

<h3>4. <strong>ApplicationDbContext</strong></h3>

```csharp
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }
    }
}

```

<h3>5. <strong>Services</strong></h3>
<h4><code>OrderService.cs</code></h4>

```csharp
using Core.Data;
using Core.Data.ViewModel;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        void HandleOrder(Order order);
        void PlaceOrder(OrderViewModel orderViewModel);
    }
}

```

```csharp
using Core.Data;
using Core.Data.ViewModel;
using Core.Repo.Interface;
using Core.Services.BehavioralPatterns.Command;
using Core.Services.CreationalPatterns.AbstractFactory;
using Core.Services.CreationalPatterns.Singleton;
using Core.Services.Interfaces;


namespace Core.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly LogService _logService;
        private readonly IOrderFactory _orderFactory;
        public OrderService(IOrderRepository repo, LogService logService, IOrderFactory orderFactory)
        {
            _repo = repo;
            _logService = logService;
            _orderFactory = orderFactory;
        }
        public void HandleOrder(Order order)
        {
            var orderProcessor = _orderFactory.CreateOrder();
            orderProcessor.ProcessOrder(order);  // Process the order using the appropriate order type

            var shippingProcessor = _orderFactory.CreateShipping();
            shippingProcessor.ShipOrder(order);  // Ship the order using the appropriate shipping type
        }
        public void PlaceOrder(OrderViewModel orderViewModel)
        {
            ICommand command = new PlaceOrderCommand(new Order());
            var id = _repo.PlaceOrder(orderViewModel);
            // Log the action
            _logService.Log($"Order {id} placed successfully.");
        }
        public void CancelOrder(OrderViewModel orderViewModel)
        {
            ICommand command = new CancelOrderCommand(new Order());
            var id = _repo.PlaceOrder(orderViewModel);
            // Log the action
            _logService.Log($"Order {id} placed successfully.");
        }
    }


}

```

<h4><code>ProductService.cs</code></h4>

```csharp
using Core.Data;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}

```

```csharp
using Core.Data;
using Core.Services.Interfaces;

namespace Core.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductService _repo;

        public ProductService(IProductService repo)
        {
            _repo = repo;
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _repo.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }
    }

}

```

<h3>Explanation of <code>ProductService</code></h3>
<ol>
<li><strong><code>GetAllProducts</code></strong>: Retrieves all products from the database.</li>
<li><strong><code>GetProductById</code></strong>: Fetches a specific product by its ID.</li>
<li><strong><code>AddProduct</code></strong>: Adds a new product to the database.</li>
<li><strong><code>UpdateProduct</code></strong>: Updates the details of an existing product.</li>
<li><strong><code>DeleteProduct</code></strong>: Removes a product from the database.</li>
</ol>

<h3>6. <strong>JWT Authentication</strong></h3>
<h4><code>TokenService.cs</code></h4>


```csharp
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService
{
    private const string SecretKey = "YourJWTSecretKey12345!"; // Change this key
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

    public string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var credentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

```

<h3>7. <strong>Controllers</strong></h3>
<h4><code>AuthController.cs</code></h4>

```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(ApplicationDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserViewModel model)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        var token = _tokenService.GenerateToken(user.Username);
        return Ok(new { Token = token });
    }
}

```

<h4><code>ProductController.cs</code></h4>

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] Product product)
    {
        _productService.AddProduct(product);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _productService.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        _productService.DeleteProduct(id);
        return Ok();
    }
}


```

<h4><code>OrderController.cs</code></h4>

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [Authorize]
    public IActionResult PlaceOrder([FromBody] OrderViewModel orderViewModel)
    {
        _orderService.PlaceOrder(orderViewModel);
        return Ok();
    }
}

```

<h3>8. <strong>Middleware Configuration for JWT in <code>Program.cs</code></strong></h3>

```csharp
// After app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

```

<h3>Complete the Application</h3>
<p>To fully complete this project:</p>
<ol>
<li><strong>Database Initialization</strong>: Populate the <code>ApplicationDbContext</code> with initial data for testing.</li>
<li><strong>Additional Controllers and Services</strong>: Expand as needed for managing users, payments, etc.</li>
<li><strong>Error Handling and Validation</strong>: Ensure all input is validated and proper error handling is in place.</li>
<li><strong>Security Enhancements</strong>: Use secure password storage practices (e.g., hashing, salting).</li>
</ol>
<p>This skeleton provides a robust starting point to build upon and demonstrate the use of design patterns within an ASP.NET Core 8 Web API project for an e-commerce application.</p>


<p>This skeleton provides a solid starting point to demonstrate how each design pattern could be implemented in an ASP.NET Core Web API project for an e-commerce application. You can expand on this by implementing the actual business logic, connecting to a real database, handling errors, and more.</p>

