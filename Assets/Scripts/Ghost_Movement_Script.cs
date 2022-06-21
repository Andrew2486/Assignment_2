using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost_Movement_Script : MonoBehaviour //Running with keyboard
{
    private Animator anim;
    public Transform target;
    public Transform self;
    Rigidbody2D rb;
    BoxCollider2D bc;

    public float SPEED = 0.2f;
    public Vector2 motion; //Move direction

    private void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            motion = direction;
        }
    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
        self = GameObject.Find("Ghost").transform;
    }
    public void FixedUpdate()
    {
        if (target)
        {
            anim.Play("Ghost_Walk");
            rb.velocity = new Vector2(motion.x, motion.y) * SPEED;
        }
        if (!target)
        {
            anim.Play("Ghost_idle");
        }
    }
    public void stop()
    {
        this.rb.velocity = Vector2.zero;
        Debug.Log("Working");
    }
}
