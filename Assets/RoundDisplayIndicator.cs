using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplayIndicator : MonoBehaviour {
    public Text roundIndicator;

	// Use this for initialization
	void Start () {
        roundIndicator.text = "Round " + (AppConstants.currentRound+1) + "/" + AppConstants.numRounds;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
