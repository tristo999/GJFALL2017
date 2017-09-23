using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public float damageMultiplier = 1.0f;
    public Collider atkcl;
    public string attackAxis = "ATK";
    public float forceUp;
    public float cooldown = 0f;
    public float initCooldown = 2f;
    public float getAtk;
    public bool attacked = false;
    
	// Use this for initialization
	void Start () {
        atkcl = GetComponentInChildren<Collider>();
	}
    void OnTriggerEnter(Collider atkcl)
    {
            if (atkcl.tag == "Player")
        {
            Vector3 direction = transform.forward.normalized;
            atkcl.attachedRigidbody.AddForce(direction.x * damageMultiplier, forceUp, direction.z * damageMultiplier);
            attacked = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.fixedDeltaTime;
        getAtk = Input.GetAxis(attackAxis);
        if (getAtk > 0 && cooldown < 0f)
        {
            atkcl.enabled = true;
            cooldown = 2f;
        }
        if ((atkcl.enabled && cooldown < 0f) || attacked)
        {
            atkcl.enabled = false;
            cooldown = initCooldown;
            attacked = false;
        }
    }
    public float getDamageMultiplier()
    {
        return damageMultiplier;
    }
}
