using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.SceneManagement;

public class Boss_Controller : MonoBehaviour
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




    public Timer summonTimer = null;
    [SerializeField]
    public GameObject Ghost;
    bool Can_Summon = false;
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
        if (Can_Summon)
        {
            Debug.Log("Ghost has spawned in and it is comming for you");
            GameObject newEnemy = Instantiate(Ghost, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
            Can_Summon = false;
            
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
        self = GameObject.Find("Boss").transform;
        TimerSummonStart();
    }
    public void FixedUpdate()
    {
        if (target)
        {
            anim.Play("Boss_Walk");
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
        //    if (sprite.flipX == true)//Moves AOE to front of sprite when flipped
      //      {
        //        attackpoint.transform.position = sprite.transform.position + new Vector3(-0.2f, 0f, 0f);
         //   }
         //   else
          //  {
         //       attackpoint.transform.position = sprite.transform.position + new Vector3(0.2f, 0f, 0f);
         //   }
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, player);
            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("We Hit: " + player.name);
                player.GetComponent<Player_stats>().Takedamage(attack);
                anim.Play("Boss_Attack");
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
        GetComponent<Boss_Controller>().stop();
        GetComponent<Boss_Controller>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        anim.Play("Boss_Death");
        SceneManager.LoadScene("End_Game_Scene");
        summonTimer.Stop();
    }
    void TimerSummonStart()
    {//summons a mob every 6 seconds
        summonTimer = new Timer();
        summonTimer.Elapsed += new ElapsedEventHandler(DisplaySummonEvent);
        summonTimer.Interval = 6000f;
        summonTimer.Start();
     //   Can_Summon = true;
        Debug.Log("Timer has started");
    }

    public void DisplaySummonEvent(object source, ElapsedEventArgs e)
    {//called when the mob is summoned
        Debug.Log("summon animation");
        Can_Summon = true;
      //  GameObject newEnemy = Instantiate(Ghost, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
    }
        /*
        private Animator anim;
        public SpriteRenderer sprite;
        public int MaxHealth = 200; //placeholder
        public int CurrentHealth = 200;
        public Timer summonTimer = null;
        public Timer projectileTimer = null;
        [SerializeField]
        public GameObject Ghost;

        // Start is called before the first frame update
        void Start()
        {
            CurrentHealth = MaxHealth;
            TimerSummonStart();
            TimerProjectileStart();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void TakeDamage(int damage) //dmg event
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            Debug.Log("Boss Died");
            this.enabled = false;
            summonTimer.Stop();
            projectileTimer.Stop();
            //game win screen here
        }

        void TimerSummonStart()
        {//summons a mob every 6 seconds
            summonTimer = new Timer();
            summonTimer.Elapsed += new ElapsedEventHandler(DisplaySummonEvent);
            summonTimer.Interval = 6000;
            summonTimer.Start();
        }

        public void DisplaySummonEvent(object source, ElapsedEventArgs e)
        {//called when the mob is summoned
            Debug.Log("summon animation");
            GameObject newEnemy = Instantiate(Ghost, new Vector2(Random.Range(-5f, 5f), Random.Range(-6f, 6f)), Quaternion.identity);
        }

        void TimerProjectileStart()
        {//fires projectile every 3 seconds
            projectileTimer = new Timer();
            projectileTimer.Elapsed += new ElapsedEventHandler(DisplayProjectileEvent);
            projectileTimer.Interval = 3000;
            projectileTimer.Start();
        }

        public void DisplayProjectileEvent(object source, ElapsedEventArgs e)
        {//called when the projectile is fired
            Debug.Log("projectile animation");
        }
        */
    }
