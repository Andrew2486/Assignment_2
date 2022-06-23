using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer_Script_Level_One : MonoBehaviour
{
    public float timeLeft = 120; //Timer in seconds
    public bool TimerOn = false;
    [SerializeField]
    public GameObject Ghost;
    
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
                if (timeLeft < 55 && timeLeft > 54.8)
                {
                    GameObject newEnemy = Instantiate(Ghost, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
                    

                    Debug.Log("Spawned");
                }
            }
            //(else if) At seconds spawn units repeat until level one completed
            else
            {
                SceneManager.LoadScene("Level_Two");
            }
        }
    }
}
