using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reveals the Kitchen Key, which is hidden behind the wall crack. Made by Chris.

public class RevealKey : MonoBehaviour
{
    public GameObject kitchenKey;
    //calls wallcrack.cs
    private wallcrack wallDestroyed;
    void Start()
    {
        wallDestroyed = GetComponent<wallcrack>();
    }

    //reveals key when wall is completely cracked (image is set to wallcrack4)
    void Update()
    {
        if (wallDestroyed.wallCracked == true)
        {
            kitchenKey.SetActive(true);
        }
        else
        {
            kitchenKey.SetActive(false);
        }
    }
}
