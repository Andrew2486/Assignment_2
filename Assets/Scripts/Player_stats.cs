using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator anim;
    public int attack = 1;
    public int defence = 1;
    public int maxhealth = 10;
    public int currenthealth = 10;
    public bool is_Attacking = false;
    public bool can_Attack = true;
    public float attack_timer = 0.5f;
    public Vector2 RespawnPoint;

    public Transform attackpoint;
    public float attackRange = 0.5F;
    public LayerMask enemy;



    public AudioSource audioSource;
    public AudioClip Attack_clip;
    public AudioClip Hurt_clip;
    public AudioClip Death_clip;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }
  //  public GameObject raycastobject;
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
                if (enemy.name == "Ghost" || enemy.name == "Ghost(Clone)")//Checks to see if Ghost type enemy
                {
                    enemy.GetComponent<Ghost_Stats>().TakeDamage(attack);
                }
                else if (enemy.name == "Vampire" || enemy.name == "Vampire(Clone)")// Checks to see if Vampire type enemy
                {
                    enemy.GetComponent<Vampire_Controller>().TakeDamage(attack);
                }
                else if (enemy.name == "Witch" || enemy.name == "Witch(Clone)")// Checks to see if Vampire type enemy
                {
                    enemy.GetComponent<Witch_Movement>().TakeDamage(attack);
                }
                else if (enemy.name == "Spider" || enemy.name == "Spider(Clone)")// Checks to see if Vampire type enemy
                {
                    enemy.GetComponent<Spider_Controller>().TakeDamage(attack);
                }
            }
            is_Attacking = true;//Doing nothing right now (checks if player is attacking)
            can_Attack = false;// Doing nothing right now (Checks if the player can attack(time))
            anim.Play("Player_Attack");
            audioSource.PlayOneShot(Attack_clip);

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
    public void Takedamage(int dmg)
    {
        audioSource.PlayOneShot(Hurt_clip);
        currenthealth -= dmg;
        if (currenthealth <= 0)
        {
           // Death();
        }
    }
    void Death()
    {
        //on all HP removed death then respawn if lives >= 0 
        audioSource.PlayOneShot(Death_clip);
        transform.position = RespawnPoint;
    }
}
