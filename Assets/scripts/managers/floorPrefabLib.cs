using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorPrefabLib : MonoBehaviour {

    public Dictionary<Vector2, int> floorInd = new Dictionary<Vector2, int>();
    public List<Vector2> floors;
    public List<GameObject> floorPrefabs;

    private void Start()
    {
        for (int n=0;n<floors.Count;n++)
        {
            floorInd[floors[n]] = n;
        }
    }

}
