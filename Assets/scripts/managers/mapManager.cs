using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour {

    public Vector2 curMap;
    public Transform player;
    public GameObject floorPrefab;
    public Transform curFloor;

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
        if (exitDir == "north")
        {
            player.localPosition = new Vector3(curPos.x, curPos.y, -5f);
            curMap = new Vector2(curMap.x, curMap.y + 1);
        }
        else if (exitDir == "south")
        {
            player.localPosition = new Vector3(curPos.x, curPos.y, 5f);
            curMap = new Vector2(curMap.x, curMap.y - 1);
        }
        else if (exitDir == "east")
        {
            GameObject newFloor = new GameObject();
            newFloor.transform.localPosition = new Vector3(10, 0, 0);
            GameObject.Instantiate(floorPrefab, newFloor.transform);
            player.GetComponent<CharacterController>().enabled = false;

            StartCoroutine(repoPlayer(curPos));
        }
        else if (exitDir == "west")
        {
            player.localPosition = new Vector3(5f, curPos.y, curPos.z);
            curMap = new Vector2(curMap.x - 1, curMap.y);
        }

    }

    IEnumerator repoPlayer(Vector3 curPos)
    {
        yield return new WaitForSeconds(1);

        player.localPosition = new Vector3(-5f, curPos.y, curPos.z);
        curMap = new Vector2(curMap.x + 1, curMap.y);
        player.GetComponent<CharacterController>().enabled = true;
    }

}
