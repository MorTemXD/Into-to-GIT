namespace ConsoleApp1.Singletone;

using System;


public sealed class GameStore
{
    private static GameStore instance;
    private static readonly object lockObject = new object();


    private GameStore()
    {

    }

    public static GameStore Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new GameStore();
                }
                return instance;
            }
        }
    }
    
    public void PurchaseGame(string gameTitle)
    {
        Console.WriteLine($"Покупка гри '{gameTitle}' в інтернет-магазині комп'ютерних ігор");
    }

    public void DisplayGameList()
    {
        Console.WriteLine("Список доступних комп'ютерних ігор:");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        GameStore store = GameStore.Instance;
        
        store.DisplayGameList();
        store.PurchaseGame("Cyberpunk 2077");
        
        GameStore anotherStore = GameStore.Instance;
        Console.WriteLine("Are the instances the same? " + (store == anotherStore)); // Виведе "True"
    }
}