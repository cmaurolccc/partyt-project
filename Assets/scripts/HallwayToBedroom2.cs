using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayToBedroom2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Bedroom2");
    }
}
