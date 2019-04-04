using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShedToOutside : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Outside");
    }
}
