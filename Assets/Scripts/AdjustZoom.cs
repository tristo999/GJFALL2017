using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustZoom : MonoBehaviour {

    public float minBoomLength = 10;

    public float boomRatio;
    public float boomLength;
    private Vector3 offsetDir;
    public float maxZoomSpeed;
 

	// Use this for initialization
	void Start () {
        offsetDir = transform.position.normalized;
        boomLength = transform.position.magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        float maxDistance = GameObject.Find("Player Center").GetComponent<PlayerPosition>().maxDist;
        boomLength = maxDistance * boomRatio;
        if(boomLength<minBoomLength)
        {
            boomLength = minBoomLength;
        }
    }

    void LateUpdate()
    {
        Vector3 newPos = offsetDir * boomLength + GameObject.Find("Player Center").transform.position;
        Vector3 diff = newPos - transform.position;

        if (diff.magnitude > maxZoomSpeed * Time.deltaTime)
        {
            transform.position += diff.normalized * maxZoomSpeed        * Time.deltaTime;

        }
        else
        {
            transform.position = newPos;
        }
    }
}
