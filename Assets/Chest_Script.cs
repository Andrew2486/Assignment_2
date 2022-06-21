using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Script : MonoBehaviour
{
    public int Attack_Increase = 1;
    public int Defence_Increase = 1;
    public int Health_Increase = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindWithTag("Player") == true)
        {
            GetComponent<Player_stats>();
        }
    }
}
