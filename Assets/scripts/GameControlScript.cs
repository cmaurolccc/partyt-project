using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    //Singleton class to manage persistence between scenes
    //static reference to the instance of the GameControlScript
    public static GameControlScript instance;

    public bool GameOver = false;
    public int Row;
    public int Col;
    // this is the 2D array of the room map
    public int[,] roomGridArray =
       {
            {2,4,3,5 },
            {7,1,0,0 },
            {0,0,0,1 },
            {1,0,0,6 },
            {0,0,1,0 },
            {0,0,4,0 },
            {0,2,8,0 },
            {9,10,0,7 },
            {0,8,0,0 },
            {8,0,0,0 }
        };
    //this is the info presented to the player as they navigate rooms
    public string[] roomInfo =
            {
                "This rooom is red.",
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
