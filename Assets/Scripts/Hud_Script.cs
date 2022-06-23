using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud_Script : MonoBehaviour
{
    public Slider slider;
    public Text textBox;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HP(int health)
    {
       // GetComponent<Player_stats>().Takedamage(1);
        Debug.Log("Damage Taken: " + health);
        slider.value = health;
    }
    public void Set_Max_HP(int health)
    {
      //  GetComponent<Player_stats>().Takedamage(health);
        Debug.Log("Damage Taken: " + health);
        slider.maxValue = health;
        slider.value = health;
    }
}
