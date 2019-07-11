using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gustBehavior : MonoBehaviour {

    public Vector3 windDir;
    public GameObject player;
    public bool on;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("gusted");
            //other.GetComponent<CharacterController>().enabled = false;
            other.GetComponent<movement>().isEffect = true;
            other.GetComponent<movement>().isGusted = true;
            player = other.gameObject;
            on = true;
        }
    }
    private void Update()
    {
        if (on)
        {
            on = player.GetComponent<movement>().isGusted;
            player.transform.position += windDir;
        }

    }
}
