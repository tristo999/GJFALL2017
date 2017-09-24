using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {


    public Dropdown ddNumPlayers;
    public Dropdown ddNumRounds;
    public Button playButton;

    private int numPlayers;
    private int numRounds;

    public int[] numPlayerOptions = { 2, 3, 4 };
    public int[] numRoundOptions = { 5, 10, 20 };


    // Use this for initialization
    void Start()
    {
        playButton.onClick.AddListener(new UnityEngine.Events.UnityAction(startGame));
        numPlayers = 2;
        numRounds = 5;
    }

    private void startGame()
    {
        Text numPlayersText = ddNumPlayers.GetComponentInChildren<Text>();
        Text numRoundsText = ddNumRounds.GetComponentInChildren<Text>();

        numPlayers = Int32.Parse(numPlayersText.text.Split(' ')[0]);
        numRounds = Int32.Parse(numRoundsText.text.Split(' ')[0]);

        Debug.Log("numPlayers = " + numPlayers);
        Debug.Log("numRounds = " + numRounds);

        AppConstants.numPlayers = numPlayers;
        AppConstants.numRounds = numRounds;
        AppConstants.currentRound = 0;

        SceneManager.LoadScene(1);
    }
}

