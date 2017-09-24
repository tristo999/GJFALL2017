using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPlayerControls : MonoBehaviour {

    public GameObject[] players;

    void Start () {
        for (int i = 0; i < players.Length; i++)
        {
            if (AppConstants.playerInMatch[i])
            {
                players[i].GetComponent<PlayerMovement>().hAxis = "Horizontal" + AppConstants.playerControls[i];
                players[i].GetComponent<PlayerMovement>().vAxis = "Vertical" + AppConstants.playerControls[i];
                players[i].GetComponent<PlayerMovement>().jumpAxis = "Jump" + AppConstants.playerControls[i];
                players[i].GetComponent<PlayerMovement>().GetComponentInChildren<AttackManager>().attackAxis = "ATK" + AppConstants.playerControls[i];
                players[i].GetComponent<PlayerMovement>().GetComponentInChildren<ShoutController>().attackAxis = "Shout" + AppConstants.playerControls[i];
                Debug.Log("P" + i + " controls: " + AppConstants.playerControls[i]);
            }
        }
    }
	
}
