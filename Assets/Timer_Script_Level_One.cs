using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Script_Level_One : MonoBehaviour
{
    public float timeLeft = 120; //Timer in seconds
    public bool TimerOn = false;
    void Start()
    {
        TimerOn = true;
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            //(else if) At seconds spawn units repeat until level one completed
            else
            {
                SceneManager.LoadScene("Level_Two");
            }
        }
    }
}
