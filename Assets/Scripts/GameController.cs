using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject[] players;
    public GameObject UI;
    public GameObject EndScreen;
    public bool[] endGame;
    public float endCool = 5f;
    public bool roundEnd = false;
    public bool scoreAdded = false;
    public GameObject killBox;
    public GameObject playerText1;
    public GameObject playerText2;
    public GameObject playerText3;
    public GameObject playerText4;


    // Use this for initialization
    void Start () {
		for(int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(AppConstants.playerInMatch[i]);
        }
        endCool = 0;
        endGame = new bool[]{ false, false, false, false};
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
                if (players[i].activeSelf && !scoreAdded )
                {
                    AppConstants.score[i]++;
                    scoreAdded = true;
                    AppConstants.currentRound++;
                    killBox.SetActive(false);
                }
            }
            if (AppConstants.currentRound < AppConstants.numRounds)
            {
                if (endCool < 0)
                {
                    endCool = 5f;
                    if (roundEnd)
                    {
                        SceneManager.LoadScene(1);
                    }
                    roundEnd = true;
                }
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

                if (winners.Count <= 1 && endCool < 0)
                {
                    UI.SetActive(false);
                    EndScreen.SetActive(true);
                    Debug.Log(winners[0]);
                    endGame[winners[0]] = true;
                    endCool = 5;
                    for (int i = 0; i < endGame.Length; i++)
                    {
                        if (endGame[i])
                        {
                            if (i == 0)
                            {
                                playerText1.SetActive(true);
                            } else if (i == 1)
                            {
                                playerText2.SetActive(true);
                            } else if (i == 2)
                            {
                                playerText3.SetActive(true);
                            } else
                            {
                                playerText4.SetActive(true);
                            }
                        }
                    }
                }
                else if (EndScreen.activeSelf)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    AppConstants.playerInMatch = new bool[] { false, false, false, false };
                    for (int i = 0; i < winners.Count; i++)
                    {
                        AppConstants.playerInMatch[winners[i]] = true;
                    }
                }
            }

        }
        endCool -= Time.deltaTime;
    }
}
