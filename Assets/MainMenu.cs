using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Level_One");
        }
    }
    public void ExitButton()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Application.Quit();
            Debug.Log("Game closed");
        }
    }
}
