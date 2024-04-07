using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating addresses
        Address address1 = CreateAddress();

        // Creating customers
        Console.WriteLine("\nEnter customer details:");
        Customer customer1 = CreateCustomer(address1);

        // Creating products
        Console.WriteLine("\nEnter product details:");
        Product product1 = CreateProduct();
        Product product2 = CreateProduct();
        Product product3 = CreateProduct();

        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);


        // Displaying packing label, shipping label, and total price for each order
        Console.WriteLine("\nOrder 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
    }

    static Address CreateAddress()
    {
        Console.WriteLine("\nEnter address details:");
        Console.Write("Street Address: ");
        string streetAddress = Console.ReadLine();
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("State/Province: ");
        string stateProvince = Console.ReadLine();
        Console.Write("Country: ");
        string country = Console.ReadLine();
        return new Address(streetAddress, city, stateProvince, country);
    }

    static Customer CreateCustomer(Address address)
    {
        Console.Write("Customer Name: ");
        string name = Console.ReadLine();
        return new Customer(name, address);
    }

    static Product CreateProduct()
    {
        Console.Write("\nProduct Name: ");
        string name = Console.ReadLine();
        Console.Write("Product ID: ");
        string productId = Console.ReadLine();
        Console.Write("Price Per Unit: ");
        double pricePerUnit = double.Parse(Console.ReadLine());
        Console.Write("Quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        return new Product(name, productId, pricePerUnit, quantity);
    }
}