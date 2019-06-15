using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("switchA"))
        {
            print("button A is pressed");
        }
        if (Input.GetButtonDown("switchB"))
        {
            print("button B is pressed");
        }
        if (Input.GetButtonDown("switchY"))
        {
            print("button Y is pressed");
        }
        if (Input.GetButtonDown("switchX"))
        {
            print("button X is pressed");
        }

    }
}
