using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DungeonExplorer;

namespace DungeonExplorer
{
    ///<summary>
    ///Main entry point fot the game.
    ///</summary>
    class Program
    {
      ///<summary>
      /// Main method that starts the game and initializes it
      ///<param "args"> Command-line argument(not used in application)</param>
        
        
    
        static void Main(string[] args)
        {  
            //instantiate and starts the game
            Game game = new Game();
            game.StartGame(); // initializes the game and rooms
            game.GameLoop(); // runs game loop
        }

    

        
    }

}
