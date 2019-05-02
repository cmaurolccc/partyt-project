using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Exits the game. Made by Chris.

public class Exit : MonoBehaviour
{   //This makes it so that the game exits when you click the Exit button.
    private void OnMouseDown()
    {
        Application.Quit();
    }
}
