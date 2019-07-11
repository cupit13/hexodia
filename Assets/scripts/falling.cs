using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour {

    public Vector2 lastPos;

    IEnumerator returnToPos(Transform obj, Vector2 pos2)
    {
        yield return new WaitForSeconds(1);
        obj.position = new Vector3(pos2.x - 4.5f, 0.58f, pos2.y - 4.5f);

        obj.gameObject.GetComponent<CharacterController>().enabled = true;
        obj.gameObject.GetComponent<movement>().isFalling = false;
        obj.gameObject.GetComponent<movement>().isEffect = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //print("falling");
            if (!other.gameObject.GetComponent<movement>().isDashing)
            {
                movement movScript = other.GetComponent<movement>();
                movScript.isGusted = false;
                movScript.isFalling = true;
                other.GetComponent<CharacterController>().enabled = false;

                other.transform.position = new Vector3(transform.position.x, 0, transform.position.z);

                lastPos = movScript.lastPos;
                StartCoroutine(returnToPos(other.transform, lastPos));
            }

        }
    }
}
