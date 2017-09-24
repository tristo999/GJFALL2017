using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject[] players;


	// Use this for initialization
	void Start () {
		for(int i = 0; i < players.Length; i++)
        {
            if (i < AppConstants.numPlayers)
            {
                players[i].SetActive(true);
            }
            else
            {
                players[i].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
