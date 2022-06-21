using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private int attack = 1;
    private int defence = 1;
    private int maxhealth = 10;
    private int currenthealth = 10;
    private bool is_Attacking = false;
    private bool can_Attack = true;
    private float attack_timer = 0.5f;
    public Vector2 RespawnPoint;


    public Transform attackpoint;
    public float attackRange = 0.5F;
    public LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }
    public GameObject raycastobject;
    public void FixedUpdate()//more stable update your FPS doesnt affect it
    {
       // Attack();
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
        if (Input.GetKey(KeyCode.K))//Temp test on respawn point
        {
            Death();
        }
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))//under update or If function has issues
        {
            if (sprite.flipX == true)//Moves AOE to front of sprite when flipped
            {
                attackpoint.transform.position = sprite.transform.position + new Vector3(-0.2f,0f,0f);
            }
            else 
            {
                attackpoint.transform.position = sprite.transform.position + new Vector3(0.2f, 0f, 0f);
            }
            Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemy);
            foreach (Collider2D enemy in hitEnemies)
            {
            Debug.Log("We Hit: " + enemy.name);
            enemy.GetComponent<Ghost_Stats>().TakeDamage(attack);
            }
            is_Attacking = true;//Doing nothing right now (checks if player is attacking)
            can_Attack = false;// Doing nothing right now (Checks if the player can attack(time))
            anim.Play("Player_Attack");

        }
    }
    public void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
    void Takedamage()
    { 
    //On damage taken Hp is removed
    }
    void Death()
    {
        //on all HP removed death then respawn if lives >= 0 
        transform.position = RespawnPoint;
    }
}
