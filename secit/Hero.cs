using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    Rigidbody2D regid;
    public float speedX;
    Animator Am;
    SpriteRenderer ap;
    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        regid = GetComponent<Rigidbody2D>();
        ap = GetComponent<SpriteRenderer>();
        Am = GetComponent<Animator>();
      

    }

    // Update is called once per frame
    void Update()
    {

       

        if(canJump == false){
            return;
        }


        float x = Input.GetAxis("Horizontal")*speedX;
        regid.velocity = new Vector2(x,regid.velocity.y);

        Am.SetFloat("beWalk",Mathf.Abs(x));

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            regid.velocity = new Vector2(regid.velocity.x,5);
            Am.SetBool("beJump",true);
            canJump = false;
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ap.flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ap.flipX = false;
        }
        if(Input.GetMouseButtonDown(1))
        {
            Am.SetBool("Attack",true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            Am.SetBool("Attack",false);
        }
      
    
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag =="floor")
        {
            Am.SetBool("beJump",false);
            canJump = true;
        }
    }
}
