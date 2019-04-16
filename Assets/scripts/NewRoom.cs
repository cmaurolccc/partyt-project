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
    public string needs;                         //this is what is needded in the room
    public int pos = 0;                           //this is the position of the items in the list
    public string[] items = new string[3];  // this stores the names of the items for a given room's puzzle


    private void Awake()
    {  // connect to the game controller object and the script attached to it
        theGameController = GameObject.Find("GameController");
        theControllerScript = theGameController.GetComponent<GameControlScript>();

        DisableCollectedItems();

        InventoryHUD();

        theCurrentScene = SceneManager.GetActiveScene().name;
        string theRoomNumber = theCurrentScene.Substring(5);
        myLocation = int.Parse(theRoomNumber);
        //how many items do i need for this room?
        totItemsNeeded = theControllerScript.roomNeedsArray[myLocation - 1].Length;

        totalItemsFound = 0;
        if (totItemsNeeded != 0)
        {
            foreach (string item in theControllerScript.roomNeedsArray[myLocation - 1])
            {
                //does the inventory list have what we need?
                bool haveIt = theControllerScript.InventoryList.Contains(item);
                if (haveIt)
                {
                    totalItemsFound += 1;
                }

                if (totalItemsFound == totItemsNeeded)
                {
                    //we have all we need to solve the puzzle in this room
                    int result = theControllerScript.InventoryList.IndexOf(item);
                    if (result != -1)
                    {
                        Debug.Log("Found " + item + " at " + result);
                        theControllerScript.InventoryList.Remove(item);
                        InventoryHUD();
                    }
                }
            }

        if (theControllerScript.InventoryList.Count != 0)
        {
            //we have loaded inventory in the list and need to show it
            for (int i = 0; i < theControllerScript.InventoryList.Count; i++)
            {
                theInventoryItem = "Inventory";
                theItemName = theControllerScript.InventoryList[i];
                adjustNum = i + 1;
                numToString = adjustNum.ToString();
                theInventoryItem += numToString;
                invGameObj = GameObject.Find("Canvas/Vertical Panel/" + theInventoryItem);
                if (invGameObj == null)
                {
                    Debug.Log("null reference");
                }
                newItem = invGameObj.GetComponent<Text>();
                newItem.text = theItemName;
            } //end of for loop
        }  //end of it statement
        theCurrentScene = SceneManager.GetActiveScene().name;
        string theRoomNumber = theCurrentScene.Substring(5);
        myLocation = int.Parse(theRoomNumber);
        Debug.Log("in new room = " + myLocation);
        //this tells me how many items I need for this room
        totItemsNeeded = theControllerScript.roomNeedsArray[myLocation - 1].Length;
        totalItemsFound = 0;   //set the total items found to 0 to start before looking for them
        Debug.Log("the total items needed = " + totItemsNeeded);

        for (int i = 1; i <= totItemsNeeded; i++)
        {
            for (int col = 0; col < theControllerScript.roomNeedsArray[myLocation - 1].Length; col++)
            {
                // is there an item needed in this room?
                if (theControllerScript.roomNeedsArray[myLocation - 1][col] != "")
                {
                    needs = theControllerScript.roomNeedsArray[myLocation - 1][col];
                    pos = theControllerScript.InventoryList.IndexOf(needs);
                    if (pos != -1) //found it
                    {
                        items[totalItemsFound] = needs;
                        totalItemsFound += 1;

                    } //end of inner if
                } //end of if
                if (totalItemsFound - 1 == totItemsNeeded)
                {
                    Debug.Log("All items needed in this room are found");
                }
            } //end of for
        }
    }
    public void DisableCollectedItems()
    {
        //disable items that have been collected
        foreach (string invItem in theControllerScript.InventoryList)
        {
            GameObject anObject = GameObject.Find(invItem);
            if (anObject != null)
            {
                Destroy(anObject);
            }
        }
    }
    public void InventoryHUD()
    {
        if (theControllerScript.InventoryList.Count != 0)
        {
            //clear the HUD first
            for (int k = 1; k< 11; k++)
            {
                string invName = "Inventory" + k.ToString();
                invGameObj = GameObject.Find("Canvas/Vertical Panel/" + invName);
                newItem = invGameObj.GetComponent<Text>();
                newItem.text = "";
            }
            //now show the collected inventory in the list that remains
            for (int i = 0; i < theControllerScript.InventoryList.Count; i++)
            {
                theInventoryItem = "Inventory";
                theItemName = theControllerScript.InventoryList[i];
                adjustNum = i + 1;
                numToString = adjustNum.ToString();
                theInventoryItem += numToString;
                invGameObj = GameObject.Find("Canvas/Vertical Panel/" + theInventoryItem);
                if(invGameObj == null)
                {
                    Debug.Log("null reference");
                }
                newItem = invGameObj.GetComponent<Text>();
                newItem.text = theItemName;
            }
        }
    }
}
