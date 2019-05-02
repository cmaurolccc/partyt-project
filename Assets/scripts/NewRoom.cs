using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewRoom : MonoBehaviour
{
    public GameObject theGameController;
    public GameControlScript theControllerScript;
    public string theInventoryItem;
    public string numToString;
    public string theItemName;
    public Text newItem;
    public GameObject invGameObj;
    public int adjustNum;
    // these variables are needed to solve puzzles and persist inventory
    public int totItemsNeeded;              //how many items are needed in this room
    public int totalItemsFound;              // how many of the needed items are found
    public int puzzlesSolved;                 //the number of solved puzzles toward the win condition
    public int myLocation;                      //the room I am in
    public string theCurrentScene;         //the name of the room I am in
  //  public string needs;                         //this is what is needded in the room
   // public int pos = 0;                           //this is the position of the items in the list
  //  public string[] items = new string[3];  // this stores the names of the items for a given room's puzzle


    private void Awake()
    {  // connect to the game controller object and the script attached to it
        theGameController = GameObject.Find("GameController");
        theControllerScript = theGameController.GetComponent<GameControlScript>();

        //get rid of the items we have already collected
        DisableCollectedItems();
        //setup the HUD to reflect what is currently in inventory
        InventoryHUD();

        theCurrentScene = SceneManager.GetActiveScene().name;
        string theRoomNumber = theCurrentScene.Substring(5);
        myLocation = int.Parse(theRoomNumber);
        //how many items do I need for this room?
        totItemsNeeded = theControllerScript.roomNeedsArray[myLocation - 1].Length;

        totalItemsFound = 0;

        if (totItemsNeeded != 0)
        {
            //figure out if we have the number of items we need by adding to totalItemsFound
            foreach (string item in theControllerScript.roomNeedsArray[myLocation - 1])
            {
                //does the inventory list have what we need?
                bool haveIt = theControllerScript.InventoryList.Contains(item);
                if (haveIt)
                {
                    totalItemsFound += 1;
                  
                }
            }
             if (totalItemsFound == totItemsNeeded)
                {
                    //we have all we need to solve the puzzle in this room
                    foreach (string item in theControllerScript.roomNeedsArray[myLocation-1])
                        {
                            int result = theControllerScript.InventoryList.IndexOf(item);
                            if (result != -1)// Each of these controller script changes make a room go from locked to unlocked in the game control script. Remember we are working with arrays if you make 
                        //changes. Also it goes N S E W in the array from left to right. Also make sure in the Room Needs Array to make sure that the item is listed in the room in needs to unlock a door.
                        //For each additional room to lock just add at the end dudes- gideon.
                                {
                                    theControllerScript.roomGridArray[1, 1] = 9;
                                }
                                {
                                  theControllerScript.roomGridArray[9, 1] = 11;
                                }
                    {
                        theControllerScript.roomGridArray[2, 3] = 4;
                    }
                                {
                        theControllerScript.roomGridArray[4, 1] = 6;
                                }
                                {
                        // THis changes a single room from being locked to unlocked.
                                    theControllerScript.roomGridArray[8, 1] = 10;
                                }
                            {
                                Debug.Log("Found " + item + " at " + result);
                                theControllerScript.InventoryList.Remove(item);
                                //we add the item to the list of items used to solve puzzles so it will not reappear
                                theControllerScript.InventoryUsed.Add(item);
                                InventoryHUD();
                            }
                        }
                    InventoryHUD();
            }
            }
        }     
    public void DisableCollectedItems()
    {
        // disable all the items in this room that have been collected
        foreach (string invItem in theControllerScript.InventoryList)
        {
            GameObject anObject = GameObject.Find(invItem);
            if (anObject != null)
            {
                Destroy(anObject);
            }
        }

        //disable all the items in this room that have been used to solve puzzles
        foreach(string usedItem in theControllerScript.InventoryUsed)
        {
            GameObject aUsedGameObject = GameObject.Find(usedItem);
            if (aUsedGameObject != null)
            {
                Destroy(aUsedGameObject);
            }
        }
    }

    public void InventoryHUD()
    {
       // if (theControllerScript.InventoryList.Count != 0)
       // {
            //clear the HUD first
            for (int k = 1; k< 11; k ++)
            {
                string invName = "Inventory" + k.ToString();
                invGameObj = GameObject.Find("Canvas/Panel/" + invName);
                newItem = invGameObj.GetComponent<Text>();
                newItem.text = "";
            }
            //now show the collected inventory in the list that remains
            for ( int i = 0; i < theControllerScript.InventoryList.Count; i++)
            {
                theInventoryItem = "Inventory";
                theItemName = theControllerScript.InventoryList[i];
                adjustNum = i + 1;
                numToString = adjustNum.ToString();
                theInventoryItem += numToString;
                invGameObj = GameObject.Find("Canvas/Panel/" + theInventoryItem);
                if (invGameObj == null)
                {
                    Debug.Log("null reference");
                }
                newItem = invGameObj.GetComponent<Text>();
                newItem.text = theItemName;
            }
       // }
    }
}
