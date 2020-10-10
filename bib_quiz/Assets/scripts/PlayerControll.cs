using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using System.Data;
using Mono.Data.SqliteClient;
using System.Diagnostics;
using System.Data.SQLite;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class PlayerControll : MonoBehaviour
{

    private bool jump = false;
    public float moveForce = 20;
    public float maxSpeed = 10;
    public float jumpForce = 700;
    public Transform groundCheck;

    private bool grounded = false;
    private float hForce = 1;
    private bool spinDash = false;
    private Rigidbody2D rb2d;
    private bool estaVivo = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Onground", grounded);

        if (grounded)
        {
            anim.SetBool("jump", false);
        }
       
        
    
    }


    private void FixedUpdate()
    {
        if (estaVivo)
        {
            anim.SetFloat("speed", rb2d.velocity.x);
            rb2d.AddForce(Vector2.right * hForce * moveForce);

            if (rb2d.velocity.x > maxSpeed)
                rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (jump)
        {
            anim.SetBool("jump", true);
            rb2d.AddForce(new Vector2(0, jumpForce));
            jump = false;
        
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            jump = true;
        }

    }
  



}

