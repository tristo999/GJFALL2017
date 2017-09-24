using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour {

    public Text[] scores;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < scores.Length; i++)
        {
            if (AppConstants.playerInMatch[i])
            {
                scores[i].text = "P" + (i + 1) + ": " + AppConstants.score[i];
            }else
            {
                scores[i].text = "";
            }
        }
	}
}
