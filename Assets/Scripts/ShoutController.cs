using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutController : MonoBehaviour {


    public int numShoutsLeft = 3;
    public float shoutMultiplier = 1.0f;
    public Collider atkcl;
    private MeshRenderer shoutCone;
    public string attackAxis = "ATK";
    public float forceUp;
    public float cooldown = 2f;
    private float initCooldown = 2f;
    public float getAtk;
    public bool attacked = false;

    private int maxNumShots;
    private float timeSinceLastShout;

    // Use this for initialization
    void Start () {
        atkcl = GetComponentInChildren<MeshCollider>();
        maxNumShots = numShoutsLeft;
        timeSinceLastShout = 0.0f;
        initCooldown = cooldown;
        shoutCone = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter(Collider atkcl)
    {
        if (atkcl.tag == "Player")
        {
            Vector3 direction = -transform.forward.normalized;
            atkcl.attachedRigidbody.AddForce(direction.x * shoutMultiplier, forceUp, direction.z * shoutMultiplier);
            attacked = true;
            
        }
    }
    // Update is called once per frame
    void Update () {
        if (numShoutsLeft < maxNumShots)
        {
            timeSinceLastShout+= Time.deltaTime;
            if (timeSinceLastShout > AppConstants.shoutRefreshTime)
            {
                timeSinceLastShout -= AppConstants.shoutRefreshTime;
                numShoutsLeft++;
            }
        }

        cooldown -= Time.deltaTime;
        getAtk = Input.GetAxis(attackAxis);
        if (getAtk > 0 && cooldown < 0f &&numShoutsLeft>0)
        {
            atkcl.enabled = true;
            //shoutCone.enabled = true;
            shoutCone.GetComponentInChildren<ParticleSystem>().Emit(100);
            cooldown = initCooldown;
            numShoutsLeft--;
        }

        if ((atkcl.enabled && cooldown < 0f) || attacked)
        {
            atkcl.enabled = false;
            //shoutCone.enabled = false;
            attacked = false;
        }
    }


    public int getNumShoutsLeft()
    {
        return numShoutsLeft;
    }
}
