using System.Runtime.CompilerServices;

namespace WakingSkeleton.Test;

public class Tests
{

    [Test]
    public void AddAnItemWhenSufficientStockIsAvailable()
    {
        var order = new Order();
        var product = new Product(1, "Test Product", 10);
        order.AddItem(product.Id);
        product.HoldStock(1);

        Assert.That(order.Items.ContainsKey(product.Id));
        Assert.That(product.Hold, Is.EqualTo(1));
        Assert.That(order.Items.Count, Is.EqualTo(1));
    }
}

public class Order
{
    public Dictionary<int, int> Items = new Dictionary<int, int>();

    public void AddItem(int itemId)
    {
        var currentCount = this.Items.GetValueOrDefault(itemId, 0);
        this.Items[itemId] = ++currentCount;
    }
}

public class Product
{
    public int Id { get; private set; }
    private string _description;
    public int Stock { get; private set; }
    public int Hold { get; private set; }

    public Product(int id, string description, int stock)
    {
        Id = id;
        _description = description;
        Stock = stock;
        Hold = 0;
    }

    public void HoldStock(int holdQuantity)
    {
        this.Hold += holdQuantity;
    }
}
