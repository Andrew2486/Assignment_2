using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Stats : MonoBehaviour
{
    public int MaxHealth = 2;
    public int CurrentHealth = 2;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy Died");
        GetComponent<Ghost_Movement_Script>().stop();
        GetComponent<Ghost_Movement_Script>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
