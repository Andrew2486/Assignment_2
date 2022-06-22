using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_3_Timer : MonoBehaviour
{
    public float timeLeft = 120; //Timer in seconds
    public bool TimerOn = false;
    [SerializeField]
    public GameObject Ghost;
    public GameObject Vampire;
    public GameObject Witch;

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
                if (timeLeft < 115 && timeLeft > 114.8)
                {
                    GameObject newEnemy = Instantiate(Ghost, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
                    GameObject newEnemyV = Instantiate(Vampire, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
                    GameObject newEnemyW = Instantiate(Witch, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);


                    Debug.Log("Spawned");
                }
            }
            //(else if) At seconds spawn units repeat until level one completed
            else
            {
                SceneManager.LoadScene("Level_Four");
            }
        }
    }
}
