﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopTestScript : MonoBehaviour {

    [SerializeField]
    GameObject stump;

    bool canHarvest = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit tree");
        GameObject stumpChopped = Object.Instantiate(stump);
        stumpChopped.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(this.gameObject);
    }
}
