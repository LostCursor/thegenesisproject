using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallCuller : MonoBehaviour {

    private Rigidbody John_Rigidbody;
    private OrthoFollower followerScript;
    private Vector3[] DirectionList =
    {
        Vector3.left,
        Vector3.back,
    };
    private HashSet<GameObject> wallList;
    private static int layerMask = (1 << 9) | (1 << 8);
    // Use this for initialization
    void Start () {
        John_Rigidbody = GetComponent<Rigidbody>();
        followerScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OrthoFollower>();
        wallList = new HashSet<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        HashSet<GameObject> hitList = new HashSet<GameObject>();
        HashSet<GameObject> removeList = new HashSet<GameObject>();
        if (!followerScript.flipped)
        {
            for (int i = 0; i < DirectionList.Length; i++)
            {
                RaycastHit hit;
                Physics.Raycast(John_Rigidbody.transform.position, DirectionList[i], out hit, 7f, layerMask);
                hitList.Add(hit.collider.gameObject);
            }
            foreach (GameObject wall in wallList) {
                if (!hitList.Contains(wall))
                {
                    wall.layer = 9;
                    removeList.Add(wall);
                }
            }
            foreach (GameObject hit in hitList)
            {
                if(!wallList.Contains(hit))
                {
                    wallList.Add(hit);
                    hit.layer = 8;
                }
            }
            foreach (GameObject remove in removeList)
            {
                wallList.Remove(remove);
            }
        }
        else
        {
            for (int i = 0; i < DirectionList.Length; i++)
            {
                RaycastHit hit;
                Physics.Raycast(John_Rigidbody.transform.position, -DirectionList[i], out hit, 7f, layerMask);
                hitList.Add(hit.collider.gameObject);
            }
            foreach (GameObject wall in wallList)
            {
                if (!hitList.Contains(wall))
                {
                    wall.layer = 9;
                    removeList.Add(wall);
                }
            }
            foreach (GameObject hit in hitList)
            {
                if (!wallList.Contains(hit))
                {
                    wallList.Add(hit);
                    hit.layer = 8;
                }
            }
            foreach (GameObject remove in removeList)
            {
                wallList.Remove(remove);
            }
        }
	}
}
