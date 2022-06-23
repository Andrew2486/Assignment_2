using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Stats : MonoBehaviour
{
    private Animator anim;
    public int MaxHealth = 2;
    public int CurrentHealth = 2;
    public int attack = 1;
    public Transform attackpoint;
    public float attackRange = 0.5F;
    public LayerMask player;
    public SpriteRenderer sprite;

    public float attack_cooldown = 1f;
    public float last_attack = -9999f;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > last_attack + attack_cooldown)
        {
            Attack();
            last_attack = Time.time;
        }
    }
    public void Attack()
    {
        {
          //  if (sprite.flipX == true)//Moves AOE to front of sprite when flipped
          //  {
           //     attackpoint.transform.position = sprite.transform.position + new Vector3(-0.2f, 0f, 0f);
           // }
           // else
           // {
           //     attackpoint.transform.position = sprite.transform.position + new Vector3(0.2f, 0f, 0f);
           // }
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, player);
            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("We Hit: " + player.name);
                player.GetComponent<Player_stats>().Takedamage(attack);
                anim.Play("Ghost_Attack");
            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            Debug.Log("Lost not found");
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
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
        anim.Play("Ghost_Death");

    }
}
