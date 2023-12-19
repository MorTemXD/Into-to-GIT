namespace ConsoleApp1.fm;

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

public class Program
{
    static void Main(string[] args)
    {
        GameFactory actionGameFactory = new ActionGameFactory();
        Game actionGame = actionGameFactory.CreateGame();
        actionGame.Play();

        GameFactory adventureGameFactory = new AdventureGameFactory();
        Game adventureGame = adventureGameFactory.CreateGame();
        adventureGame.Play();
    }
}