using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    Vector3 lookHere;
    float mouseInput;
    
    void Start () {
        
	}
	

	void Update () {

        mouseInput = Input.GetAxis("Mouse Y");

        lookHere = new Vector3(mouseInput, 0, 0);

        transform.Rotate(-lookHere);


	}
}
