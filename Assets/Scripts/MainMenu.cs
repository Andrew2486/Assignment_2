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
    public void How_To_Play()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("How_to_play");
        }
    }
    public void Story()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Story");
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
