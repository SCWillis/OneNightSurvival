using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopTestScript : MonoBehaviour {

    [SerializeField]
    GameObject stump;

    [SerializeField]
    GameObject axe;

    bool harvested = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if (other == axe)
        {

            Debug.Log("hit tree");
            //GameObject stumpChopped = Object.Instantiate(stump);
            Instantiate(stump, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //stumpChopped.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(this.gameObject);
        }
    }
}
