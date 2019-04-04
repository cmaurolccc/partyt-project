using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementToBathroom : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Bathroom");
    }
}
