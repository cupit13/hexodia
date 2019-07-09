using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge : MonoBehaviour {

    public movement movScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edge")
        {
            movScript.isOnEdge = true;
            movScript.lastPos = movScript.roundedPos;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "edge")
        {
            movScript.isOnEdge = false;
        }
    }
}
