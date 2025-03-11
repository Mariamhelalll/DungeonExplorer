using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DungeonExplorer;

namespace DungeonExplorer
{
    ///<summary>
    /// represents a player in the game having 3 attributes which are name, health and inventory.
    /// additionally, the class provides methods that manage , helath, inventory and interactions with the Dungeon Explorer room.
    /// </summary>
      public class Player
    {
      ///<summary>
      /// Set only during object creation, gets player's name.
      ///</summary>
      public string Name{get; private set;} // can only be modified in the constructor due to the private setter
      private int health; // encapsulation
      private List<string> inventory; // encapsulation ( ensures direct modification is not possible outside the class)
      
      ///<summary>
      /// Initializes a new instance of the player class
      ///</summary>
      ///<param "name"> Represents the name of the player.</param>
      ///<param "health"> Represents the starting default health value as 100, with a mninimum of 0.</param>

      public Player (string name , int health=100)
        {
           Debug.Assert(!string.IsNullOrWhiteSpace(name),"Name of player can not be empty!");

           Name= name;
           Health = health;
           inventory= new List<string>();
        }

     ///<summary>
     ///Gets or sets the health attribute with the value constraints (0 to 100).
     ///</summmary>

      public int Health // encapsulation (controls how health is modified)
        {
           get {return health;}
           set
             {
               Debug.Assert(value >=0 && value <=100 , "Health has a minimum of 0 and a maximum of 100");

              if (value < 0)
        
              health = 0; // prevents assignment to negative health values
        
             else if (value >100)
        
              health = 100; // prevents assignment to health values greater than 100
         
             else

               health = value;
        
            }
       }

      ///<summary>
      ///Gets the player's inventory as a string which is already formatted ( i.e having commas seperating the different items).
      ///</summary>

      public string Inventory
         {
           // encapsulation : ensures direct modification is not possible outside the class.
           get {return inventory.Count >0 ? string.Join("," , inventory.Select(item=>$"\"{item}\"")) :"Empty";} // Read only property to return a formatted string if item is not empty.

        }
     
     ///<summary>
     /// allows the player to pick up an item from the current room and add it to the inventory.
     /// </summmary>
     /// <param "item">The item to be picked up.</param>
     /// <param "room"> The room containing the item.</param>

     
      public void PickUpItem(string item , Room room)
         {
           Debug.Assert(room!= null ,"Room can not be unidentified");
           Debug.Assert(!string.IsNullOrWhiteSpace(item), "Item can not be unidentified");
        
           if (!string.IsNullOrWhiteSpace(room.Item))
             {
            
               inventory.Add(room.Item);
               Console.WriteLine($"You picked up a {item}");
               room.DiscardItem();
            }    

          else
             {
               Console.WriteLine("No item to pick from  this room!");
        
            
            }
        
        
        }

    
     ///<summary>
     ///Removes an item from the player's inventory
     ///</summary>
     ///<param "item">The item to be removed.</param>

      public void ReleaseItem(string item) // encapsulates management of inventory
         {
            Debug.Assert(!string.IsNullOrWhiteSpace(item),"Item to be released can not be empty!");

            if (inventory.Contains(item))
              {
               inventory.Remove(item);
               Console.WriteLine($"You released {item}");
            }

           else
             {
               Console.WriteLine($"You do not have any {item} in the inventory!");

            }
        }

     ///<summary>
     /// Reduces player's health by a specified amount.
     ///</summary>
     ///<param "quantity">The amount of damage to apply.</param>

      public void Damage(int quantity)
         {
            Debug.Assert(quantity >0 , "Damage quantity is positive!");

            Health -= quantity;
            Console.WriteLine($"{Name} accepted {quantity} damage. Current health : {Health}");


        }

     ///<summary>
     /// player re-gains health by a specified amount
     ///</summary>
     ///<param "quantity"> The amount of health to regain.</param>

      public void Heal( int quantity)
          {
          Debug.Assert( quantity>0 ,"Heal quantity is positive"); 

         Health += quantity;
         Console.WriteLine($"{Name} re-gained {quantity} points. Current health:{Health} ");

        }

     /// <summary>
     ///Dispalys the player's current status which are : name, health and inventory
     /// </summary>

    
       public void DisplayPlayer()
         {
            Console.WriteLine($"Player's name : {Name} , Player's health : {Health} , Inventory : {Inventory}");


        }
    }  
}



