using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float hMoveSpeed;
    [SerializeField]
    float vMoveSpeed;


	// Use this for initialization
	void Start ()
    {
        hMoveSpeed = 150.0f;
        vMoveSpeed = 3.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * hMoveSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vMoveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        
    }
}
