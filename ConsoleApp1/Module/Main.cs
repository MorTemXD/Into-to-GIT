namespace DefaultNamespace;

using System;

public sealed class OnlineStore
{
    private static OnlineStore instance;
    private static readonly object lockObject = new object();
    
    private OnlineStore()
    {
    }
    
    public static OnlineStore Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new OnlineStore();
                }
                return instance;
            }
        }
    }
    
    public void DisplayProducts()
    {
        Console.WriteLine("Список доступних товарів у магазині");
    }

    public void ProcessOrder(string product)
    {
        Console.WriteLine($"Обробка замовлення товару: {product}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        OnlineStore store = OnlineStore.Instance;
        
        store.DisplayProducts();
        store.ProcessOrder("Гра Cyberpunk 2077");
        
        OnlineStore anotherStore = OnlineStore.Instance;
        Console.WriteLine("Are the instances the same? " + (store == anotherStore)); // Виведе "True"
    }
}