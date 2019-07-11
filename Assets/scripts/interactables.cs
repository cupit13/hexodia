using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactables : MonoBehaviour {

    public GameObject interactUI;
    public movement movScript;
    public GameObject textObj;

    void allPowerReset()
    {
        movScript.powerFire = false;
        movScript.powerWind = false;
    }

    private void Update()
    {
        if (interactUI.activeInHierarchy)
        {
            if (Input.GetKeyDown("i"))
            {
                textObj.SetActive(true);
                movScript.isEffect = true;
                interactUI.SetActive(false);
            }
        }

        if (textObj.activeInHierarchy)
        {
            if (Input.GetKeyDown("f"))
            {
                allPowerReset();
                movScript.powerFire = true;
                movScript.isEffect = false;
                textObj.SetActive(false);
            }
            if (Input.GetButtonDown("Jump"))
            {
                allPowerReset();
                movScript.powerWind = true;
                movScript.isEffect = false;
                textObj.SetActive(false);
            }
        }
    }
}
