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
using System.Collections.Specialized;

public class PlayerControll : MonoBehaviour
{
    public float speed = 0f;
    public bool isGrounded = true;
    public float jumpForce = 650f;
    private Animator anim;
    private Rigidbody2D rig;

    public LayerMask LayerGround;
    public Transform checkGround;
    public string isGroundBool = "eChao";


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MovimentaPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.touchCount > 0)
        {
            Jump();
        }
    }
    private void MovimentaPlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if (Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, LayerGround)) {

            anim.SetBool(isGroundBool, true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool(isGroundBool, false);
            isGrounded = false;
        }
    }

    public void Jump()
    {
     
        

            if (isGrounded)
        {
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, jumpForce));
        }
    }
    void OnTriggerEnter2D()
    {
        UnityEngine.Debug.Log("Bateu");
    }
}

