using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Game
{
    private Player player;
    private List<Room> rooms;
    private int presentRoomIndicator;

    public void StartGame()
    {
        string playerName;
        do
        {
            Console.Write("Enter your player's name : ");
            playerName = Console.Readline();
            if(string.IsNullOrWhiteSpace(playerName))
            {
                Console.WriteLine("Invalid input : Player's name can not be empty!");
            } 
        }while (string.IsNullOrWhiteSpace(playerName));

            player= new Player (playerName);
            StartRooms();

            Console.WriteLine ("\nWelcome to DungeonExplorer!");



        }
    }


    public void StartRooms()
    {
        rooms= new List<Room>
        {
            new Room("A dark,mysterious dungeon room with a sword on the ground.","Sword"),
            new Room (" A creepy corridor with a shield in the wall.", "Shield"),
            new Room ("A treasure hall filled with gold with a potion glowing on the table.","Potion"),
            new Room("A compact room with a monster sneaking.","")

        };

        Debug.Assert(rooms.Count>0, "At least one room should be present in order to start.");

        presentRoomIndicator=0;
    }

    public void GameLoop()
    {
        bool playing= true;
        while(playing)
        {
            Room thisRoom = rooms[presentRoomIndicator];

            Console.WriteLine("\n" + thisRoom.Description);
            Console.WriteLine("Options : (1) Pick up item , (2) Check status , (3) Release item , (4) Move to the next room , (5) Accept damage , (6) Heal from damage , (7) Exit ");
            Console.WriteLine("Please choose an option from the above! : ");
            string option = Console.ReadLine()?.Trim();

            switch (option)
            {
                case "1":
                {
                 player.PickUPItem(thisRoom.Item, thisRoom);
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
                    string itemToRelease= Console.Readline();
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
                    break;
    
                }

                default:
                Console.WriteLine("Error: Invalid option,please try again ! ");
                break;

            }




        }
    }

    private void MoveToFollowingRoom()
    {
        if(presentRoomIndicator < rooms.Count -1)
        {
            presentRoomIndicator++;
            Console.WriteLine("You moved to the next room successfully ! ");
        }

        else
        {
            Console.WriteLine("No more rooms are left !");
        }
    }

}