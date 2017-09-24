using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {


    public Dropdown ddNumRounds;
    public Button playButton;

    public Dropdown[] playerControls;

    public List<String> playerControlMap;

    private int numPlayers;
    private int numRounds;

    private int[] score = { 0, 0, 0, 0 };
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
        assignControls();
        assignGameConstants();
        
        SceneManager.LoadScene(1);
    }

    private void assignGameConstants()
    {
        numPlayers = 0;

        Text player1ControlsText = playerControls[0].GetComponentInChildren<Text>();
        Text player2ControlsText = playerControls[1].GetComponentInChildren<Text>();
        Text player3ControlsText = playerControls[2].GetComponentInChildren<Text>();
        Text player4ControlsText = playerControls[3].GetComponentInChildren<Text>();


        AppConstants.playerInMatch = new bool[]
        {
            !player1ControlsText.text.Equals("None"),
            !player2ControlsText.text.Equals("None"),
            !player3ControlsText.text.Equals("None"),
            !player4ControlsText.text.Equals("None")
        };
        
        for(int i = 0; i < AppConstants.playerInMatch.Length; i++)
        {
            if (AppConstants.playerInMatch[i])
            {
                numPlayers++;
            }
        }


        Text numRoundsText = ddNumRounds.GetComponentInChildren<Text>();

        numRounds = Int32.Parse(numRoundsText.text.Split(' ')[0]);

        Debug.Log("numPlayers = " + numPlayers);
        Debug.Log("numRounds = " + numRounds);


        AppConstants.numPlayers = numPlayers;
        AppConstants.numRounds = numRounds;
        AppConstants.currentRound = 0;
        AppConstants.score = score;
    }

        


    private void assignControls()
    {
        Text player1ControlsText = playerControls[0].GetComponentInChildren<Text>();
        Text player2ControlsText = playerControls[1].GetComponentInChildren<Text>();
        Text player3ControlsText = playerControls[2].GetComponentInChildren<Text>();
        Text player4ControlsText = playerControls[3].GetComponentInChildren<Text>();

        AppConstants.playerControls = new int[]{
            playerControlMap.IndexOf(player1ControlsText.text),
            playerControlMap.IndexOf(player2ControlsText.text),
            playerControlMap.IndexOf(player3ControlsText.text),
            playerControlMap.IndexOf(player4ControlsText.text)
        };
    }
}

