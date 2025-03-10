using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Player
{
    public string Name{get; private set;} // can only be modified in the constructor due to the private setter
    private int health; // encapsulation
    private List<string> inventory; // encapsulation ( ensures direct modification is not possible outside the class)

    public Player (string name , int health=100)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(name),"Name of player can not be empty!");

        Name= name;
        Health = health;
        inventory= new List<string>();
    }

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

    public string Inventory
    {
        // encapsulation : ensures direct modification is not possible outside the class.
        get {return inventory.Count >0 ? string.Join("," , inventory.Select(item=>$"\"{item}\"")) :"Empty";} // Read only property to return a formatted string if item is not empty.

    }
     
     // Method to pick up item from the room.
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

    //Additional method to release item

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

    //Additional method to loose helath points

    public void Damage(int quantity)
    {
        Debug.Assert(quantity >0 , "Damage quantity is positive!");

        Health -= quantity;
        Console.WriteLine($"{Name} accepted {quantity} damage. Current health : {Health}");


    }

    //Additional method to re-gain health points

    public void Heal( int quantity)
    {
        Debug.Assert( quantity>0 ,"Heal quantity is positive"); 

        Health += quantity;
        Console.WriteLine($"{Name} re-gained {quantity} points. Current health:{Health} ");

    }

    // Method to display player's status
     public void DisplayPlayer()
     {
        Console.WriteLine($"Player's name : {Name} , Player's health : {Health} , Inventory : {Inventory}");


     }
}

