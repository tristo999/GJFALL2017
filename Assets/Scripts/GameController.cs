using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject[] players;
    public GameObject UI;
    public GameObject EndScreen;
    public int[] endGame;


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
        int[] score = { 0, 0, 0, 0 };
    AppConstants.score = score;
	}
	
	// Update is called once per frame
	void Update () {
        int activeCount = players.Length;
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].activeSelf)
            {
                activeCount--;
            }
        }
        if (activeCount == 1)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].activeSelf)
                {
                    AppConstants.score[i]++;
                }
            }
            AppConstants.currentRound++;
            if (AppConstants.currentRound < AppConstants.numRounds)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                UI.SetActive(false);
                EndScreen.SetActive(true);
            }
        }
	}
}
