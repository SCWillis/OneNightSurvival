﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float hMoveSpeed;
    [SerializeField]
    float vMoveSpeed;
    [SerializeField]
    public float speed = 2;

    //[SerializeField]
    float jumpSpeed = 700;
    int maxJumps = 1;
    int jumps;

    [SerializeField]
    Terrain terrain;


    //animations
    [SerializeField]
    GameObject lamp;

    [SerializeField]
    GameObject axe;

    Animator lampAnim;
    Animator axeAnim;
   

    void Start ()
    {
        hMoveSpeed = 10.0f;
        vMoveSpeed = 10.0f;
        jumps = maxJumps;

        lampAnim = lamp.GetComponent<Animator>();
        axeAnim = axe.GetComponent<Animator>();

        lampAnim.enabled = false;
        axeAnim.enabled = false;

    }
	
	
	void Update ()
    {

        keyboardControls();
        if(Input.GetMouseButton(0) == true)
        {
            SwingAxe(true);
        }
        else
        {
            SwingAxe(false);
        }
        /*
        string[] joy = Input.GetJoystickNames();

        //test to see if gamepad is connected
        if (joy.Length == 0)
        {
            keyboardControls();
        }
        else
        {
            gamepadControls();
        }
      */
        

    }

    //reset jumps
    /*
    void OnTriggerEnter(Collider other)
    {
        if(other == terrain.GetComponent<TerrainCollider>())
        {
            jumps = maxJumps;
            
        }
    }
    */
    private void OnCollisionEnter(Collision col) //works better, no need for second collider on player now
    {
        if (col.gameObject.tag == "Ground")
        {
            jumps = maxJumps;
        }
    }

    void keyboardControls()
    {
        //move inputs
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vMoveSpeed;
        var strafe = Input.GetAxis("Horizontal") * Time.deltaTime * vMoveSpeed;
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);

        transform.Rotate(lookhere);
        transform.Translate(strafe, 0, z);


        //jump so far can jump as many times as want because no ground takes jumps away
        if(Input.GetKeyDown("space") == true && jumps > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
            jumps -= 1;
            //SwingLamp();
        }

        //**animations**//
        //Lamp animation
        SwingLamp(z, strafe);


    }

 
    void gamepadControls()
    {

        float vSpeedOffset = 15f; //to speed up gamepad movement 
        float hSpeedOffset = 15f; //to speed up gamepad movement

        var x = Input.GetAxis("HorizontalR") * Time.deltaTime * hMoveSpeed * hSpeedOffset;
        var z = Input.GetAxis("VerticalL") * Time.deltaTime * vMoveSpeed;
        var strafe = Input.GetAxis("HorizontalL") * Time.deltaTime * vMoveSpeed;
        var headTilt = Input.GetAxis("VerticalR") * Time.deltaTime * vMoveSpeed * vSpeedOffset;



        transform.Rotate(0, x, 0);
        transform.Translate(strafe, 0, z);
        Camera.main.transform.Rotate(headTilt, 0, 0);


        //jump
        if (Input.GetButtonDown("JumpGP") == true && jumps > 0)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
            jumps -= 1;
        }

        //animations

    }

    void SwingLamp(float xMove, float yMove)
    {
        if (xMove != 0f || yMove != 0f)
        {
            lampAnim.enabled = true;
        }
        else
        {
            lampAnim.enabled = false;
        }
        
    }

    void SwingAxe(bool swing)
    {
        if(swing == true)
        {
            axeAnim.enabled = true;
        }
        else
        {
            axeAnim.enabled = false;
        }
    }


}
