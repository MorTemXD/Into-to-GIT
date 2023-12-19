namespace ConsoleApp1.af;

using System;

abstract class Game
{
    public abstract void Play();
}

class ActionGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Граю в екшн-ігру");
    }
}

class AdventureGame : Game
{
    public override void Play()
    {
        Console.WriteLine("Граю в пригодницьку ігру");
    }
}

abstract class GameFactory
{
    public abstract Game CreateGame();
}

class ActionGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new ActionGame();
    }
}

class AdventureGameFactory : GameFactory
{
    public override Game CreateGame()
    {
        return new AdventureGame();
    }
}

abstract class GameGenreFactory
{
    public abstract Game CreateGame();
}

class ActionGameGenreFactory : GameGenreFactory
{
    public override Game CreateGame()
    {
        return new ActionGame();
    }
}

class AdventureGameGenreFactory : GameGenreFactory
{
    public override Game CreateGame()
    {
        return new AdventureGame();
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameFactory actionGameFactory = new ActionGameFactory();
        Game actionGame = actionGameFactory.CreateGame();
        actionGame.Play();

        GameFactory adventureGameFactory = new AdventureGameFactory();
        Game adventureGame = adventureGameFactory.CreateGame();
        adventureGame.Play();
        
        GameGenreFactory actionGameGenreFactory = new ActionGameGenreFactory();
        Game actionGenreGame = actionGameGenreFactory.CreateGame();
        actionGenreGame.Play();

        GameGenreFactory adventureGameGenreFactory = new AdventureGameGenreFactory();
        Game adventureGenreGame = adventureGameGenreFactory.CreateGame();
        adventureGenreGame.Play();
    }
}