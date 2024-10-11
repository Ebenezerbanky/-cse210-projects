using System;
using System.Collections.Generic;

// Product Class
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Getter for name
    public string GetName()
    {
        return name;
    }

    // Getter for product ID
    public string GetProductId()
    {
        return productId;
    }

    // Calculate total cost
    public decimal GetTotalCost()
    {
        return price * quantity;
    }
}

// Address Class
public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    // Constructor
    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to return full address as a string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer Class
public class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Getter for customer name
    public string GetName()
    {
        return name;
    }

    // Getter for address
    public Address GetAddress()
    {
        return address;
    }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

// Order Class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
    }

    // Add product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Calculate total price of the order
    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost based on customer's location
        total += customer.IsInUSA() ? 5 : 35;

        return total;
    }

    // Generate packing label
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return packingLabel;
    }

    // Generate shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Program Class (Main method)
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("Penson Spencer", address1);
        Customer customer2 = new Customer("Jospeh Smith", address2);

        // Create products
        Product product1 = new Product("HDMI Cable", "L123", 1000m, 2);
        Product product2 = new Product("Mouse", "M456", 20m, 5);
        Product product3 = new Product("Keyboard", "K789", 50m, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display order details for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());

        // Display order details for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}
