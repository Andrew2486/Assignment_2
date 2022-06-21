using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment_Script : MonoBehaviour
{
   // public bool flipX;
    private SpriteRenderer sprite;
    private Animator anim;
    public float SPEED = 40f;
    public Vector2 motion;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        movement();
    }
    public void movement()
    {


        //Diagonal movement
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W)))
        {
            motion = Vector2.left + Vector2.up;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.S)))
        {
            motion = Vector2.left + Vector2.down;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W)))
        {
            motion = Vector2.up + Vector2.right;
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.S)))
        {
            motion = Vector2.down + Vector2.right;
            sprite.flipX = false;
        }//Single way movement
        else if (Input.GetKey(KeyCode.A))
        {
            motion = Vector2.left;
            sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            motion = Vector2.right;
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            motion = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            motion = Vector2.down;
        }
        else
        {
            motion = Vector2.zero;
        }
    }
    public void Move()
    {
        rb.velocity = motion * SPEED * Time.deltaTime;
    }
}
