using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment_Script : MonoBehaviour
{
    private Animator anim;
    public float SPEED = 0.02f;
    public Vector2 motion;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


         gameObject.transform.position = new Vector2(transform.position.x + (h * SPEED),
         transform.position.y + (v * SPEED));
         //anim.Play("Player_Walk");
        //Frozen Constraints on Rigidbody to stop sliding


        

    }
}
