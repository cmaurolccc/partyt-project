using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hallwayp2ToBasement : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Basement");
    }

}
