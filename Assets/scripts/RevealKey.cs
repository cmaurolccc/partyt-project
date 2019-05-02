using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reveals the Kitchen Key, which is hidden behind the wall crack. Attached to the kitchen-key game object. Made by Chris.

public class RevealKey : MonoBehaviour
{
    public GameObject kitchenKey;
    void Start()
    {
        //Deactivates kitchen-key object on load, so it can be activated by wallcrack.cs
        kitchenKey.SetActive(false);
    }
}
