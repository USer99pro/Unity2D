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
    public GameObject sh;
    Transform trans;


    // Start is called before the first frame update
    void Start()
    {
        regid = GetComponent<Rigidbody2D>();
        ap = GetComponent<SpriteRenderer>();
        Am = GetComponent<Animator>();
        trans = sh.GetComponent<Transform>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            GameObject s = Instantiate(sh, trans.position, trans.rotation);
                Rigidbody2D re_s = s.GetComponent<Rigidbody2D>();
            if(ap.flipX == false){
                re_s.velocity = new Vector2(10,0);
            }
            if(ap.flipY == true){
                re_s.velocity = new Vector2(-10,0);
            }

        }


        if(Input.GetMouseButtonDown(0))
        {
            Am.SetBool("Attack",true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Am.SetBool("Attack",false);
        }
       

        if(canJump == false){
            return;
        }
        Am.SetBool("beJump", false);



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
