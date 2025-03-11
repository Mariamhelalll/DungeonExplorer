using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
 
namespace DungeonExplorer
{
    ///<summary>
    ///Represents a room in the game , containing a description and an optional item.
    ///</summary>

    public class Room // encapsulates attributes and methods
    {
        ///<summary>
        ///receives a room description
        ///</summary>
        public string Description {get; private set;}
        ///<summary>
        /// receives the item available in the room. Empty string is left if no item is available in the room.
        public string Item {get; private set;}

        ///<summary>
        ///Initialzes a new instance of the Room class
        ///</summary>
        /// <param "description"> A description of the room's details.</param>
        /// <param "item"> Reprensents an optional item available in the room (default is an empty string).</param>
        /// <exception "Argument Exception"> Conducted if the <paramref "description"/> is null or whitespace.</exception>

        public Room (string description, string item="")
       {
         Debug.Assert(!string.IsNullOrWhiteSpace(description),"Room Description can not be empty!");// ensures descrption is not empty , therefore preventing any invalid object status.
        
         Description= description;
         Item = item ?? ""; // if item is null/empty, the item is replaced with an empty string "", preventing any runtime errors.
       }

       ///<summary>
       /// Discards the current item in the room
       ///</summary>
       /// <remarks>
       /// Ensures data encapsulation and integrity by resetting the item to an empty string while discarding it.
       ///</remarks>


       public void DiscardItem() 
       {
         Item =""; 
       }

       
    } 


}

