using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HallwayToOutside : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Outside");
    }
}
