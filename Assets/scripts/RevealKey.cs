using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reveals the Kitchen Key, which is hidden behind the wall crack. Made by Chris.

public class RevealKey : MonoBehaviour
{
    public GameObject kitchenKey;
    void Start()
    {
        //deactivates key on Start, so it disappears until wallcrack.cs reactivates it.
        kitchenKey.SetActive(false);
    }
}
