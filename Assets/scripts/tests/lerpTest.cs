using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpTest : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(0.0f, 10f, 0f), 5f));
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
        objectToMove.transform.position = end;
    }

}