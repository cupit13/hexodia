using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassBehavior : MonoBehaviour {

    public GameObject parent;
    private void OnTriggerEnter(Collider other)
    {
        //print(other);
        if (other.tag == "fire")
        {
            Destroy(parent);
        }
    }
}
