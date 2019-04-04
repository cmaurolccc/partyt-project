using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BathroomtoBasement : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Basement");
    }
}
