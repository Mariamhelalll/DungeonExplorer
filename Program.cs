using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{

    static void Main(string[] args)
    {
        Game game = new Game();
        game.StartGame();
        game.GameLoop();
    }
}