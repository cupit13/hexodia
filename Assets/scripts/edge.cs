using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edge : MonoBehaviour {

    public movement movScript;
    public GameObject interactUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edge")
        {
            movScript.isOnEdge = true;
            movScript.lastPos = movScript.roundedPos;
        }else if (other.tag == "hole")
        {
            movScript.dashReady = true;
        }else if (other.tag == "interactable")
        {
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "edge")
        {
            movScript.isOnEdge = false;
        }else if(other.tag == "hole")
        {
            movScript.dashReady = false;
        }
        else if (other.tag == "interactable")
        {
            interactUI.SetActive(false);
        }
    }
}
