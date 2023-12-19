namespace ConsoleApp1.Builder;

using System;

class Game
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Genre: {Genre}, Price: {Price:C}");
    }
}

abstract class GameBuilder
{
    protected Game game;

    public void CreateGame()
    {
        game = new Game();
    }

    public abstract void BuildTitle();
    public abstract void BuildGenre();
    public abstract void BuildPrice();

    public Game GetGame()
    {
        return game;
    }
}

class ActionGameBuilder : GameBuilder
{
    public override void BuildTitle()
    {
        game.Title = "Action Game";
    }

    public override void BuildGenre()
    {
        game.Genre = "Action";
    }

    public override void BuildPrice()
    {
        game.Price = 49.99m;
    }
}

class AdventureGameBuilder : GameBuilder
{
    public override void BuildTitle()
    {
        game.Title = "Adventure Game";
    }

    public override void BuildGenre()
    {
        game.Genre = "Adventure";
    }

    public override void BuildPrice()
    {
        game.Price = 59.99m;
    }
}

class GameDirector
{
    public Game Construct(GameBuilder builder)
    {
        builder.CreateGame();
        builder.BuildTitle();
        builder.BuildGenre();
        builder.BuildPrice();
        return builder.GetGame();
    }
}

class Program
{
    static void Main(string[] args)
    {

        GameDirector director = new GameDirector();
        
        GameBuilder actionGameBuilder = new ActionGameBuilder();
        Game actionGame = director.Construct(actionGameBuilder);
        actionGame.DisplayInfo();
        
        GameBuilder adventureGameBuilder = new AdventureGameBuilder();
        Game adventureGame = director.Construct(adventureGameBuilder);
        adventureGame.DisplayInfo();
    }
}