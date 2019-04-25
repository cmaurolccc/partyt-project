using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToInventory : MonoBehaviour
{
    public GameObject theGameController;
    public GameControlScript theControllerScript;
    public Text myText;
    public Text newItem;
    public GameObject myGameObject;
    public GameObject invGameObject;
    public string theInventoryItem = "Inventory";
    public string numToString;
    public int addedItem;

    private void OnMouseDown()
    {
        theGameController = GameObject.Find("GameController");
        theControllerScript = theGameController.GetComponent<GameControlScript>();
        myGameObject = GameObject.Find("Canvas/Tell the Player");
        myText = myGameObject.GetComponent<Text>();

        if (this.tag == "I")
        {
            if (theControllerScript.InventoryList.Count < 10)
            {
                theControllerScript.InventoryList.Add(name);
                addedItem = theControllerScript.InventoryList.Count;
                Destroy(gameObject);

                numToString = addedItem.ToString();
                theInventoryItem += numToString;
                invGameObject = GameObject.Find("Canvas/Panel/" + theInventoryItem);
                newItem = invGameObject.GetComponent<Text>();
                newItem.text = name;
            }
            else
            {
                myText.text += "\nYo man, I think I can only carry 10 things in these small pockets of mine. I feel like maybe I can get rid of them by shoving them into some puzzles. Am I seriously gonna have to break the 4th wall again? I'm just ripping off Dead Pool at this point.";
            }
        }
        else
        {
            myText.text += "\nThe " + this.name + " cannot be put in inventory";
        }
    }
}