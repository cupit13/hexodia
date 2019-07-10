using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour {

    public Vector2 curMap;
    public Transform player;
    public GameObject floorPrefab;
    public Transform curFloor;
    public Transform newFloor;
    public float mapTransitionTime;
    GameObject newFloorPar;

    void loadCurMap(Vector2 map)
    {
        print(map + "loaded");
    }

	// Use this for initialization
	void Start () {

        loadCurMap(new Vector2(0,0));
    }

    public void playerExit(string exitDir)
    {
        Vector3 curPos = player.localPosition;
        Vector3 dirPos = Vector3.zero;
        Vector3 plaPos = Vector3.zero;
        Vector3 mapPos = Vector2.zero;

        player.gameObject.GetComponent<movement>().isEffect = true;

        if (exitDir == "north")
        {
            dirPos = new Vector3(0, 0, 10);
            plaPos = new Vector3(curPos.x, curPos.y, -5f);
            mapPos = new Vector2(curMap.x, curMap.y+1);

        }
        else if (exitDir == "south")
        {
            dirPos = new Vector3(0, 0, -10);
            plaPos = new Vector3(curPos.x, curPos.y, 5f);
            mapPos = new Vector2(curMap.x, curMap.y - 1);
        }
        else if (exitDir == "east")
        {
            dirPos = new Vector3(10, 0, 0);
            plaPos = new Vector3(-5f, curPos.y, curPos.z);
            mapPos = new Vector2(curMap.x + 1, curMap.y);
        }
        else if (exitDir == "west")
        {
            dirPos = new Vector3(-10, 0, 0);
            plaPos = new Vector3(5f, curPos.y, curPos.z);
            mapPos = new Vector2(curMap.x - 1, curMap.y);
        }

        newFloorPar = new GameObject();
        newFloorPar.transform.localPosition = dirPos;
        int id = GetComponent<floorPrefabLib>().floorInd[mapPos];
        floorPrefab = GetComponent<floorPrefabLib>().floorPrefabs[id];
        newFloor = Instantiate(floorPrefab, newFloorPar.transform).transform;
        player.GetComponent<CharacterController>().enabled = false;

        curFloor.SetParent(newFloorPar.transform);
        player.SetParent(newFloorPar.transform);
        StartCoroutine(MoveOverSeconds(newFloorPar, new Vector3(0, 0, 0f), mapTransitionTime));
        StartCoroutine(repoPlayer(curPos,plaPos, mapPos));
    }

    IEnumerator repoPlayer(Vector3 curPos, Vector3 plaPos, Vector2 mapPos)
    {
        yield return new WaitForSeconds(mapTransitionTime);

        player.SetParent(null);
        newFloor.SetParent(null);
        Destroy(curFloor.gameObject);
        Destroy(newFloorPar);
        curFloor = newFloor;
        player.localPosition = plaPos;
        curMap = mapPos;
        player.GetComponent<CharacterController>().enabled = true;
        player.gameObject.GetComponent<movement>().isEffect = false;
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
        if (objectToMove) {
            objectToMove.transform.position = end;
        }
        
    }

}
