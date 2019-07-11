using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action : MonoBehaviour {

    public GameObject fire;
    public Transform dirObj;
    public GameObject dash;
    Transform oriPar;
    Vector3 oriPos;
    Vector3 oriRot;

    // Update is called once per frame
    void Update()
    {
        if (!(GetComponent<movement>().isEffect || GetComponent<movement>().isFalling || GetComponent<movement>().isDashing))
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (GetComponent<movement>().powerWind)
                {
                    summonDash(1.7f);
                }
            }
            if (Input.GetButtonDown("Fire"))
            {
                if (GetComponent<movement>().powerFire)
                {
                    summonFire();
                }
            }
        }
    }


    void summonFire()
    {
        GetComponent<movement>().isEffect = true;
        GameObject instObj = Instantiate(fire, dirObj);
        StartCoroutine(destroyDelay(instObj, .3f));
    }

    void summonDash(float mag)
    {
        if (GetComponent<movement>().dashReady)
        {
            GetComponent<movement>().isEffect = true;
            GetComponent<movement>().isDashing = true;

            GameObject instObj = Instantiate(dash, dirObj);

            oriPar = dirObj.parent;
            oriPos = dirObj.localPosition;
            oriRot = dirObj.localEulerAngles;

            dirObj.localPosition = dirObj.localPosition * mag;

            dirObj.SetParent(null);
            GameObject teleport = new GameObject();
            teleport.transform.SetParent(dirObj);
            teleport.transform.localPosition = Vector3.right;
            teleport.transform.localEulerAngles = Vector3.zero;
            teleport.transform.SetParent(null);

            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(teleport.transform.position.x, transform.position.y, teleport.transform.position.z), .1f));

            StartCoroutine(destroyDelay(instObj, .8f));
            StartCoroutine(destroyDelay(teleport, .2f));
        }

    }

    IEnumerator destroyDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(obj);
        GetComponent<movement>().isEffect = false;

        if (dirObj.parent == null)
        {
            dirObj.SetParent(oriPar);
            dirObj.localPosition = oriPos;
            dirObj.localEulerAngles = oriRot;

            GetComponent<movement>().isDashing = false;

        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (objectToMove)
        {
            objectToMove.transform.position = end;
        }
    }
}
