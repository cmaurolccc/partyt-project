using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{
    //Singleton class to manage persistence between scenes
    //static reference to the instance of the GameControlScript
    public static GameControlScript instance;

    public bool GameOver = false;
    public int Row;
    public int Col;
    public List<String> InventoryList = new List<String>();

    public string[][] roomNeedsArray = new string[][]
    {
        new string[1] {"key" },
        new string[1] {""},
        new string[1] {""},
        new string[1] {""},
        new string[2] {"candle", "match stick" },
        new string[1] {""},
        new string[1] {""},
        new string[1] {""},
        new string[3] {"blue gem","green gem","red gem" },
        new string[1] {"wrench" }
    };

    // this is the 2D array of the room map
    public int[,] roomGridArray =
       {
            {0,0,2,0 }, //room 1 bedroom
            {3,9,1,8 }, //room 2 hallwayp1
            {7,2,4,5 }, //room 3 hallwayp2
            {0,0,3,0 }, //room 4 kitchen
            {0,6,3,0 }, //room 5 basement
            {5,0,0,0 }, //room 6 bathroom
            {0,3,0,0 }, //room 7 living room
            {0,0,0,2 }, //room 8 bedroom2
            {2,10,0,0 }, //room 9 outside
            {9,0,0,0 } //room 10 shed
        };
    //this is the info presented to the player as they navigate rooms
    public string[] roomInfo =
            {
                "You awaken and find yourself on the ground in a place you have never seen before. The light is dim but you can make out 2 doors. One is in front of you and one is behind you. The walls of the room are red. To try to get your bearings, you pull out your trusty compass from your pocket. You see that you are facing north. You need to find out where you are in hopes of finding your way home.  What will you do? ",
                "This room is green.",
                "This room is yellow.",
                "This room is grey.",
                "This room is too dark and you cannot see the color of the room. You feel around hoping to find a way out.",
                "This room is blue.",
                "This room is orange.",
                "This room is black.",
                "This room is fuschia.",
                "This room is lavender. There is a panel that you cannot seem to open. Perhaps a wrench would help."
            };
       void Awake()
    {
        //if the instance reference has not beem set yet
        if (instance == null)
        {
            //set this instance as the instance reference
            instance = this;
        }
        else if (instance != this)
        {
            // if the instance reference is already set and this is not the instance reference
            // destroy the game object
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
 
}
