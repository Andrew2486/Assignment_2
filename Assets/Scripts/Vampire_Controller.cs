using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire_Controller : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator anim;
    public Transform target;
    public Transform self;
    Rigidbody2D rb;

    public int MaxHealth = 2;
    public int CurrentHealth = 2;
    public int attack = 1;
    public Transform attackpoint;
    public float attackRange = 0.5F;
    public LayerMask player;

    public float attack_cooldown = 1f;
    public float last_attack = -9999f;

    public float SPEED = 0.2f;
    public Vector2 motion; //Move direction

    public void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (target.position.x >= self.position.x)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
            motion = direction;
        }
        if (Time.time > last_attack + attack_cooldown)
        {
            Attack();
            last_attack = Time.time;
        }
    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        CurrentHealth = MaxHealth;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        self = GameObject.Find("Vampire").transform;
    }
    public void FixedUpdate()
    {
        if (target)
        {
            anim.Play("Vampire_Walk");
            rb.velocity = new Vector2(motion.x, motion.y) * SPEED;
        }
    }
    public void stop()
    {
        this.rb.velocity = Vector2.zero;
        Debug.Log("Working");
    }
    public void Attack()
    {
        {
            if (sprite.flipX == true)//Moves AOE to front of sprite when flipped
            {
                attackpoint.transform.position = sprite.transform.position + new Vector3(-0.2f, 0f, 0f);
            }
            else
            {
                attackpoint.transform.position = sprite.transform.position + new Vector3(0.2f, 0f, 0f);
            }
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, player);
            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("We Hit: " + player.name);
                player.GetComponent<Player_stats>().Takedamage(attack);
                anim.Play("Vampire_Attack");
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
        Debug.Log("-= dmg");
        if (CurrentHealth <= 0)
        {
            Debug.Log("Should die now");
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy Died");
        GetComponent<Vampire_Controller>().stop();
        GetComponent<Vampire_Controller>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        anim.Play("Vampire_Death");

    }
}
