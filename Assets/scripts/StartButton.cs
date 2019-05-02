using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Code used for the start button in the main menu. Made by Chris.

public class StartButton : MonoBehaviour
{
    //Loads Room 1 (Bedroom)
    private void OnMouseDown()
    {
        SceneManager.LoadScene("room 1");
    }
}
