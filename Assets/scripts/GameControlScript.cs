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

    public List<String> InventoryUsed = new List<String>();// the inventory used code we did in class to destroy objects.

    public string[][] roomNeedsArray = new string[][]
    {
        new string[2] {"BR1Note",  "LRRapier" },
        new string[1] {"BR1Key"},
        new string[2] {"red key", "creepy painting"},
        new string[2] {"cookie dough", "kitchen key"},
        new string[2] {"candle", "match stick" },
        new string[1] {"knife"},
        new string[3] {"LRRapier", "LRGun", "LivingRoomAnimalStatue"},
        new string[1] {"bathroomkey"},
        new string[1] {"BR1Key2" },
        new string[1] {"LRRGun" },
        new string[1] {""},
        new string[1] {""}
    };

    // this is the 2D array of the room map. Set default positions to be locked. Then in new room script to change to unlocked add to the if thingy around line 59
    public int[,] roomGridArray =// added three rooms . If you are going to lock something make sure the 0's go here and change to unlocked in new room-g
       {
            {0,12,0,2 }, //room 1 bedroom
            {3,0,1,8 }, //room 2 hallwayp1
            {7,2,5,4 }, //room 3 hallwayp2
            {0,0,3,0 }, //room 4 kitchen
            {0,6,0,3 }, //room 5 basement
            {5,0,0,0 }, //room 6 bathroom
            {13,3,0,0 }, //room 7 living room
            {0,0,0,2 }, //room 8 bedroom2
            {2,0,0,0 }, //room 9 outside
            {9,0,0,0 }, //room 10 shed
            {0,0,0,0 }, // room 11 the win screen room.
            {1,0,0,0 }, // room 12  Note from room 1 leads here.  
            {0,7,0,0 } //room 13 Gideon Cove creative contribution
        };
    //this is the info presented to the player as they navigate rooms
    public string[] roomInfo =
            {
                "What the heck man, I came to this place to have some fun at a party but now I'm in some stingy, grimy house that I never even knew existed.  How the heck am I supposed to get out, gideon you suck. ",
                "Yo, this looks like a hallway bro, is this thing some kind of puzzle game, real creative chris. ",
                "Oh dang a continuation of the hallway really original bros, Zack you especially suck at this. ",
                "Finaly somewhere I care about where's the food IM STARVING, THANK YOU chris. ",
                "Yo zack great touch, time to go down to my impending doom, real cliche.",
                "While I'm here I may as well take a dump in this scuzzy house, this room sucks zack like you. ",
                "Yo bro, this would be an amazing place for D&D, yo gideon get on that NOW hook me up man. ",
                "Well at least you didn't copy paste the other bedroom angle congratulations, your creativity extends past the other 4 party members. ",
                "Yo you guys thanks for letting me out of this terrible house maybe you arn't so bad after all. ",
                "Oh good a shed full of memes, a millenials lifetime dream, also great job Zack and Josh on the shed I aprove your memes, IGN 10/10. "
            };

     //Zachary Zehner's creative addition 
    public string[] roomInfo2 =
           {
                "Wait this room was the room I woke up in. Why did I come back here, help me out player quit making me go in circles, its annoying. ",
                "back in the stupid hallway again I WANT OUT OF THIS HOUSE NOW. ",
                "PLAYER YOU SUCK QUIT MAKING ME GO IN CIRCLES ",
                "while im back here again I may as well make the most of it I'm making a sandwich. ",
                "Yo do I really gotta come down here again its real creepy.",
                "Why do you insist I go to the bathroom I DONT HAVE TO GO ANYMORE. ",
                "Still waiting for my D&D group gideon. ",
                "Yo this bed looks very comfy maybe this is all just dream, if so, I may need mental help when I wake up. ",
                "Why am I back in the yard shouldn't I be running away from this place as fast as I possibly can. ",
                "Ok player I realize your millennial brain perceives this as the best place in the world but I WANT TO GO NOW. "
            };
    public bool[] visitedBefore =
        {false, false, false, false, false, false, false, false, false, false};
    //end of Zachary Zehner's creative addition the next part is in the ShowTextInInventory script
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
