using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    private int attack = 1;
    private int defence = 1;
    private int maxhealth = 10;
    private int currenthealth = 10;
    private bool is_Attacking = false;
    private bool can_Attack = true;
    private float attack_timer = 0.5f;


    public Transform attackpoint;
    public float attackRange = 0.5F;
    public LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))//under update or If function has issues
        {
            Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemy);
            foreach (Collider2D enemy in hitEnemies)
            {
            Debug.Log("We Hit: " + enemy.name);
            enemy.GetComponent<Ghost_Stats>().TakeDamage(attack);
            }
            is_Attacking = true;
            can_Attack = false;
            

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
    void Death()
    {
        
    }
}
