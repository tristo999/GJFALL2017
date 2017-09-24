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
            players[i].SetActive(AppConstants.playerInMatch[i]);
        }
        
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
                int highestScore = 0;

                List<int> winners = new List<int>();

                for (int i = 0; i < AppConstants.score.Length; i++)
                {
                    if (AppConstants.score[i] > highestScore)
                    {
                        highestScore = AppConstants.score[i];
                    }
                }

                for (int i = 0; i < AppConstants.score.Length; i++)
                {
                    if (AppConstants.score[i] == highestScore)
                    {
                        winners.Add(i);
                    }
                }

                if (winners.Count <= 1)
                {
                    UI.SetActive(false);
                    EndScreen.SetActive(true);
                }
                else
                {
                    AppConstants.playerInMatch = new bool[] { false, false, false, false };
                    for (int i = 0; i < winners.Count; i++)
                    {
                        AppConstants.playerInMatch[winners[i]] = true;
                    }
                    SceneManager.LoadScene(1);
                }

                UI.SetActive(false);
                EndScreen.SetActive(true);
            }

        }
    }
}
