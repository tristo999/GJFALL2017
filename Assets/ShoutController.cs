using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutController : MonoBehaviour {

    public float shoutRefreshTime = 1.0f;
    public int numShoutsLeft = 3;

    private float shoutRefreshTimer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getNumShoutsLeft()
    {
        return numShoutsLeft;
    }
}
