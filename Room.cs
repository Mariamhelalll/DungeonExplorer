using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Room // encapsulates attributes and methods
{
    public string Description {get; private set;}
    public string Item {get; private set;}

    public Room (string description, string item="")
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(description),"Room Description can not be empty!");// ensures descrption is not empty , therefore preventing any invalid object status.

        Description= description;
        Item = item ?? ""; // if item is null/empty, the item is replaced with an empty string "", preventing any runtime errors.
    }

    // Additional method to remove item once it is picked up 

    public void DiscardItem() // Ensures data encapsulation and integrity
    {
        Item =""; 
    }

}