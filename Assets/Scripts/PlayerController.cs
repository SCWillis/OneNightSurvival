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


    void Start ()
    {
        hMoveSpeed = 150.0f;
        vMoveSpeed = 5.0f;
         
    }
	
	
	void Update ()
    {
        //gamepadControls();
        keyboardControls();

        /*
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            Debug.Log(transform.rotation.ToString());
        }
        */



    }
    void keyboardControls()
    {

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * hMoveSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vMoveSpeed;
        var strafe = Input.GetAxis("Horizontal") * Time.deltaTime * vMoveSpeed;

        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput*1.2f, 0);
        transform.Rotate(lookhere);

        //transform.Rotate(0, x, 0);
        transform.Translate(strafe, 0, z);

    }

 
    void gamepadControls()
    {
        var x = Input.GetAxis("HorizontalR") * Time.deltaTime * hMoveSpeed;
        var z = Input.GetAxis("VerticalL") * Time.deltaTime * vMoveSpeed;
        var strafe = Input.GetAxis("HorizontalL") * Time.deltaTime * vMoveSpeed;
        var headTilt = Input.GetAxis("VerticalR") * Time.deltaTime * vMoveSpeed;



        transform.Rotate(0, x, 0);
        transform.Translate(strafe, 0, z);
        Camera.main.transform.Rotate(headTilt, 0, 0);

        
        
    }


}
