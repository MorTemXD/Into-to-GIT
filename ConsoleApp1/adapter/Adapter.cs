namespace ConsoleApp1.adapter;

using System;


interface IOldGameStore
{
    void BuyGame(string title, decimal price);
    void DisplayGameList();
}


class OldGameStore : IOldGameStore
{
    public void BuyGame(string title, decimal price)
    {
        Console.WriteLine($"Покупка гри '{title}' за {price:C} в старому інтернет-магазині");
    }

    public void DisplayGameList()
    {
        Console.WriteLine("Список доступних ігор у старому інтернет-магазині");
    }
}


interface INewGameStore
{
    void PurchaseGame(string title);
    void ShowGames();
}

class OldToNewGameStoreAdapter : INewGameStore
{
    private readonly IOldGameStore oldGameStore;

    public OldToNewGameStoreAdapter(IOldGameStore oldGameStore)
    {
        this.oldGameStore = oldGameStore;
    }

    public void PurchaseGame(string title)
    {
        oldGameStore.BuyGame(title, 0); 
    }

    public void ShowGames()
    {
        oldGameStore.DisplayGameList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IOldGameStore oldStore = new OldGameStore();
        oldStore.BuyGame("Old Game", 29.99m);
        oldStore.DisplayGameList();
        
        INewGameStore newStore = new OldToNewGameStoreAdapter(oldStore);
        newStore.PurchaseGame("New Game");
        newStore.ShowGames();
    }
}