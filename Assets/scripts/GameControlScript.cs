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

    public List<String> InventoryUsed = new List<String>();

    public string[][] roomNeedsArray = new string[][]
    {
        new string[4] {"NoteBedroom", "BedroomKey", "BedroomPlushToy" , "BedroomKeyForShed" },
        new string[1] {""},
        new string[1] {""},
        new string[1] {""},
        new string[2] {"candle", "match stick" },
        new string[1] {""},
        new string[3] {"LivingRoomRapier", "LivingRoomGun", "LivingRoomAnimalStatue"},
        new string[1] {""},
        new string[3] {"blue gem","green gem","red gem" },
        new string[1] {"wrench" }
    };

    // this is the 2D array of the room map
    public int[,] roomGridArray =
       {
            {0,0,0,2 }, //room 1 bedroom
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
                "What the heck man, I came to this place for some food and booze but now I'm in some stingy, grimy house that I never even knew existed.  How the heck am I supposed to get out, gideon you suck. ",
                "Yo, this looks like a hallway bro, is this thing some kind of puzzle game, real creative chris. ",
                "Oh dang a continuation of the hallway really original bros, Zack you especially suck at this. ",
                "Finaly somewhere I care about where's the food IM STARVING, THANK YOU chris. ",
                "yo zack great touch, time to go down to my impending doom, real cliche.",
                "while I'm here I may as well take a dump in this scuzzy house, this room sucks josh like you. ",
                "yo bros, this would be an amazing place for D&D, yo gideon get on that NOW hook me up man. ",
                "well at least you didn't copy paste the other bedroom angle congratulations, your creativity extends past the other 4 party members. ",
                "yo you guys thanks for letting me out of this terrible house maybe you arn't so bad after all. ",
                "Oh good a shed full of memes, a millenials lifetime dream, also great job Zack and Josh on the shed I aprove your memes, IGN 10/10. "
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
