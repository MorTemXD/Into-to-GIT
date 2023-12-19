namespace ConsoleApp1.prototype;

using System;

abstract class GamePrototype
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    public abstract GamePrototype Clone();
}

class ActionGamePrototype : GamePrototype
{
    public override GamePrototype Clone()
    {
        return new ActionGamePrototype
        {
            Title = this.Title,
            Genre = this.Genre,
            Price = this.Price
        };
    }
}

class AdventureGamePrototype : GamePrototype
{
    public override GamePrototype Clone()
    {
        return new AdventureGamePrototype
        {
            Title = this.Title,
            Genre = this.Genre,
            Price = this.Price
        };
    }
}

class Client
{
    public GamePrototype CreateGameClone(GamePrototype prototype)
    {
        return prototype.Clone();
    }
}

class Program
{
    static void Main(string[] args)
    {

        Client client = new Client();
        
        GamePrototype actionGamePrototype = new ActionGamePrototype
        {
            Title = "Action Game",
            Genre = "Action",
            Price = 49.99m
        };
        
        GamePrototype clonedActionGame = client.CreateGameClone(actionGamePrototype);
        Console.WriteLine("Original Action Game:");
        DisplayGameInfo(actionGamePrototype);
        Console.WriteLine("\nCloned Action Game:");
        DisplayGameInfo(clonedActionGame);
        
        GamePrototype adventureGamePrototype = new AdventureGamePrototype
        {
            Title = "Adventure Game",
            Genre = "Adventure",
            Price = 59.99m
        };
        
        GamePrototype clonedAdventureGame = client.CreateGameClone(adventureGamePrototype);
        Console.WriteLine("\nOriginal Adventure Game:");
        DisplayGameInfo(adventureGamePrototype);
        Console.WriteLine("\nCloned Adventure Game:");
        DisplayGameInfo(clonedAdventureGame);
    }

    static void DisplayGameInfo(GamePrototype game)
    {
        Console.WriteLine($"Title: {game.Title}, Genre: {game.Genre}, Price: {game.Price:C}");
    }
}