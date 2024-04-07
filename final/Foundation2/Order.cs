class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.GetTotalCost();
        }

        // Adding shipping cost
        if (customer.GetAddress().IsInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += "Product: " + product.GetName() + " (ID: " + product.GetProductId() + ")\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return "Customer: " + customer.GetName() + "\nAddress:\n" + customer.GetAddress().GetAddressString();
    }
}