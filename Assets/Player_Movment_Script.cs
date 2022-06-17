using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movment_Script : MonoBehaviour
{

    public int SPEED = 200;
    public Vector2 motion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            // Straight movement
            if (Input.GetKeyDown("up"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
            }
            if (Input.GetKeyDown("down"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            }
            if (Input.GetKeyDown("right"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
            }
            if (Input.GetKeyDown("left"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
            }
            // diaginal movement
            /*
            if (Input.GetKey("left") && (Input.GetKey("up")))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1);
            }
            if (Input.GetKey("right") && (Input.GetKey("up")))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1);
            }
            if (Input.GetKey("left") && (Input.GetKey("down")))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1);
            }
            if (Input.GetKey("right") && (Input.GetKey("down")))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1);
            }
            */
        }
        if (Input.anyKey == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        // Stop movement
        /*
        if (Input.GetKeyUp("up"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyUp("down"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyUp("left"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyUp("right"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        */


        




















        /*
        // diaginal movement
        if (Input.GetKey("left") && (Input.GetKey("up")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1);
        }
        if (Input.GetKey("right") && (Input.GetKey("up")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1);
        }
        if (Input.GetKey("left") && (Input.GetKey("down")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1);
        }
        if (Input.GetKey("right") && (Input.GetKey("down")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1);
        }
        // Linear movement
        if (Input.GetKeyDown("up"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
        if (Input.GetKeyDown("down"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
        if (Input.GetKeyDown("right"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        }
        if (Input.GetKeyDown("left"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        }




        //Stop movement
        if (Input.GetKeyDown(null))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        */
    }
}
