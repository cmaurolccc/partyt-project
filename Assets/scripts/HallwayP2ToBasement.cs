using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayP2ToBasement : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Basement");
    }
}
