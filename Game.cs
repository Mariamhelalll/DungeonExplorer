using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DungeonExplorer;


namespace DungeonExplorer
{
    ///<summary>
    ///Game class handles the flow  and the core logic of the game
    /// initializes the player, manages room navigation and it also starts the game loop.
    ///</summary>
    public class Game
    {
     private Player player; // Represents the current player
     private List<Room> rooms; // Room list
     private int presentRoomIndicator; // Keeps track of the player's current room 
     
     /// <summary>
     /// prompts for player's name, therefore creating the player and starting the loop.
     ///</summary>
     public void StartGame()
        {
           string playerName;
           do
            {
              Console.Write("Enter your player's name : ");
              playerName = Console.ReadLine()?.Trim();
              if(string.IsNullOrWhiteSpace(playerName))
                {
                   Console.WriteLine("Invalid input : Player's name can not be empty!");
                } 
            }while (string.IsNullOrWhiteSpace(playerName));

            player= new Player (playerName); // creates player instance
            StartRooms(); // initializes the room information.

            Console.WriteLine ($"\nWelcome {playerName} to Dungeon Explorer! Let's start our adventure!");

            GameLoop(); // starting the main loop of the game.



        }
     

     ///<summary>
     /// initializes the available rooms list with their descriptions and items.
     ///</summary>
     public void StartRooms()
        {
           rooms= new List<Room>
            {
               new Room(" Room number 1 : A dark,mysterious dungeon room with a sword on the ground.","sword"),
               new Room (" Room number 2 : A creepy corridor with a shield in the wall.", "shield"),
               new Room (" Room number 3 : A treasure hall filled with gold with a potion glowing on the table.","potion"),
               new Room(" Room number 4 : A compact room with a monster sneaking.","")

            };

            Debug.Assert(rooms.Count>0, "At least one room should be present in order to start.");

            presentRoomIndicator=0;
        }

     ///<summary>
     /// this is in control of the core loop of the game, allowing the choice of actions by the player until they exit the game.
     ///</summary>

     public void GameLoop()
        {
            bool playing= true;
            while(playing)
            {
               Room thisRoom = rooms[presentRoomIndicator];

               Console.WriteLine("\n" + thisRoom.Description);
               Console.WriteLine("Options : (1) Pick up item , (2) Check status , (3) Release item , (4) Move to the next room , (5) Accept damage , (6) Heal from damage , (7) Exit , (8) Move to previous room.");
               Console.WriteLine("Please choose an option from the above! : ");
               string option = Console.ReadLine()?.Trim();
               if (string.IsNullOrWhiteSpace(option))
                {
                   Console.WriteLine("Error: Invalid input, Please try again ! ");
                   continue;
                }

                switch (option)
                {
                  case "1":
                    {
                       Console.Write("enter the item you wish to pick up from this room : ");
                       string itemToPick = Console.ReadLine()?.Trim().ToLower();   
                       player.PickUpItem(itemToPick, thisRoom);
                       break;
                    }

                  case "2":
                    {
                        player.DisplayPlayer();
                        break;
                    }

                 case "3":
                    {
                       Console.Write("Enter an item to be released : ");
                       string itemToRelease= Console.ReadLine()?.Trim().ToLower();
                       player.ReleaseItem(itemToRelease);
                       break;


        
                    }

                  case "4":
                    {
                       MoveToFollowingRoom();
                       break;
                    }

            

                  case "5":
                    {
                        player.Damage(10);
                        break;
                    }

                  case "6":
                    {
                        player.Heal(10);
                        break;
                    }

                  case "7":
                    {
                       playing = false;
                       Console.WriteLine("Thank you for playing !");
                       Console.WriteLine("To Exit, press any key !");
                       Console.ReadKey();
                       Environment.Exit(0);
                        break;
    
                    }

                  case "8":
                    {
                       MoveToPreviousRoom();
                       break;
                    }

                  default:
                    {
                      Console.WriteLine("Error: Invalid option,please try again ! ");
                      break;
                    }

                  
                }
            

            }




        }
     

     ///<summmary>
     /// moves the player to the following room if available.
     ///prints a message if no more rooms are available.
     ///</summary> 

     private void MoveToFollowingRoom()
        {
            if(presentRoomIndicator < rooms.Count -1)
            {
                presentRoomIndicator++;
                Console.WriteLine("You moved to the next room successfully ! ");
            }

            else
            {
               Console.WriteLine("You reached the final room !");
            }
        }

     ///<summary>
     /// Moves to the previous room if available
     /// prints a message if the initial room of the game is reached
     ///</summary>
     private void MoveToPreviousRoom()
        {
            if (presentRoomIndicator > 0)
            {
                presentRoomIndicator--;
                Console.WriteLine("You moved to the previous room successfully!");

            }

           else
            {
               Console.WriteLine("You are in the initial room of the game!");
            }
        }
    }
}


