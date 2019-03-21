using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openDoor : MonoBehaviour
{
    public int nextRoom;
    public string inWhichScene;

    private bool CanIGoHere(int theRoomNo)
    {
        // this determines if there is a place to go in that direction
        if (theRoomNo == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private void OnMouseDown()
    {
        string theSceneName = SceneManager.GetActiveScene().name;
        string nextScene = "";

        //this is how to reference the GameControlScript attached to the GameController object
        GameObject theGameController = GameObject.Find("GameController");
        GameControlScript controllerScript = theGameController.GetComponent<GameControlScript>();

        inWhichScene = theSceneName;
        string theRoomNumber = inWhichScene.Substring(5);
        int theNumber;
        theNumber = int.Parse(theRoomNumber);
        int goNext;
        bool OkToGo = false;

        // based on the direction, pass the correct column number

        switch (this.name)
        {
            case "North":
                goNext = controllerScript.roomGridArray[theNumber - 1, 0];
                break;
            case "South":
                goNext = controllerScript.roomGridArray[theNumber - 1, 1];
                break;
            case "East":
                goNext = controllerScript.roomGridArray[theNumber - 1, 2];
                break;
            default:
                goNext = controllerScript.roomGridArray[theNumber - 1, 3];
                break;
        }

        OkToGo = CanIGoHere(goNext);
        Debug.Log("go to room " + goNext);
        string numToStr = goNext.ToString();
        nextScene = "Room ";
        nextScene += numToStr;
        Debug.Log("Next room = " + nextScene);
        if (OkToGo)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // this will be replaced by the code that tells the user in the HUD that direction is not possible
            Debug.Log("cannot go there");
        }
    }
}
