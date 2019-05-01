using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reveals the Kitchen Key, which is hidden behind the wall crack. Made by Chris.

public class RevealKey : MonoBehaviour
{
    public GameObject kitchenKey;
    //calls wallcrack.cs
    public wallcrack wc;
    void Start()
    {
        GameObject wck = GameObject.Find("wallcrack");
        wc = wck.GetComponent<wallcrack>();
        kitchenKey.SetActive(false);
    }

    //reveals key when wall is completely cracked
    void Update()
    {
        if (wc.wallCracked == true)
        {
            kitchenKey.SetActive(true);
        }
    }
}
