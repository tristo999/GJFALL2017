using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudController : MonoBehaviour {

    public GameObject player;

    //TODO:make public and let dev in unity choose this. Need to chnage HUD though. stretch goal
    private int numShouts = 3;

    //HUD Objects
    Image[] shouts;
    Text damageMultiplier;
    
    //controllers
    private ShoutController shoutController;
    private AttackManager attackManager;


	// Use this for initialization
	void Start () {
        shouts = new Image[numShouts];

        foreach(Transform t in transform)
        {            
           if (t.name.Equals("shout1"))
                    shouts[0] = t.GetComponent<Image>();

            if (t.name.Equals("shout2"))
                    shouts[1] = t.GetComponent<Image>();

            if (t.name.Equals("shout3"))
                    shouts[2] = t.GetComponent<Image>();
                    
            if (t.name.Equals("damageMultiplier"))
                    damageMultiplier = t.GetComponent<Text>();
                    
        }

        //todo: read from attackManager
        if (damageMultiplier == null)
        {
            Debug.LogError("Error: no damage Multiplier Found");
        }

        shoutController = player.GetComponentInChildren<ShoutController>();
        if (shoutController == null)
        {
            Debug.LogError("Error: no shout controller attached to target player.");
        }

        attackManager = player.GetComponentInChildren<AttackManager>();
        if (attackManager == null)
        {
            Debug.LogError("Error: no attack manager attached to target player.");
        }

        

    }
	
	// Update is called once per frame
	void Update () {
        updateShoutText();
        updateDamageBonus();

        if (!player.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private void updateDamageBonus()
    {
        if (attackManager != null)
        {
            damageMultiplier.text = "DMG x "+(Mathf.Round(attackManager.getDamageMultiplier()* 10)/ 10.0f);
        }
    }

    private void updateShoutText()
    {
        if (shoutController != null)
        {
            numShouts = shoutController.getNumShoutsLeft();

            for (int i = 0; i < shouts.Length; i++)
            {
                if (i < numShouts)
                {
                    shouts[i].enabled = true;
                }
                else
                {
                    shouts[i].enabled = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < shouts.Length; i++)
            {
                shouts[i].enabled = false;
            }
        }
    }
}
