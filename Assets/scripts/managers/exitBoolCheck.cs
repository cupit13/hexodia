using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitBoolCheck : MonoBehaviour {

    public string exitDir;
    public mapManager map;

    private void OnTriggerEnter(Collider other)
    {
        map.playerExit(exitDir);
    }
}
