using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {
    private GameObject[] players;
    private Vector3 positionTotal;
    private Vector3 positionFinal;
    public float maxDist;
    float minX, maxX, minZ, maxZ;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        minX = Mathf.Infinity;
        maxX = -Mathf.Infinity;
        minZ = Mathf.Infinity;
        maxZ = -Mathf.Infinity;

        players = GameObject.FindGameObjectsWithTag("Player");
        positionTotal = Vector3.zero;

        foreach (GameObject player in players)
        {
            Vector3 tempPlayer = player.transform.position;
            positionTotal += tempPlayer;

            if (tempPlayer.x < minX)
                minX = tempPlayer.x;
            if (tempPlayer.x > maxX)
                maxX = tempPlayer.x;
            
            if (tempPlayer.z < minZ)
                minZ = tempPlayer.z;
            if (tempPlayer.z > maxZ)
                maxZ = tempPlayer.z;
        }

        positionFinal = (positionTotal / players.Length);
        transform.position = positionFinal;

        float sizeX = maxX - minX;
        float sizeZ = maxZ - minZ;

        maxDist = (sizeX > sizeZ ? sizeX : sizeZ);
    }
}
