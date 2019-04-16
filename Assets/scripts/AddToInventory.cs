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
        
    }
}