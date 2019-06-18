using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<movement>().isFalling = true;
            other.GetComponent<CharacterController>().enabled = false;

            other.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
