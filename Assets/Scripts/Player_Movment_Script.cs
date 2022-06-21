using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment_Script : MonoBehaviour
{

    public float SPEED = 0.02f;
    public Vector2 motion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        gameObject.transform.position = new Vector2(transform.position.x + (h * SPEED),
        transform.position.y + (v * SPEED));
    }
}
