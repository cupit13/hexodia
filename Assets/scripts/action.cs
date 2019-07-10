using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour {

    public GameObject fire;
    public Transform dirObj;

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown("Jump"))
        {
            summonFire();
        }
	}

    void summonFire()
    {
        GetComponent<movement>().isEffect = true;
        GameObject instFire = Instantiate(fire, dirObj);
        StartCoroutine(destroyDelay(instFire));
    }

    IEnumerator destroyDelay(GameObject obj)
    {
        yield return new WaitForSeconds(.3f);
        Destroy(obj);
        GetComponent<movement>().isEffect = false;
    }
}
