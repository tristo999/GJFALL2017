using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public float baseKnockback = 1.0f;
    public Collider atkcl;
    public string attackAxis = "ATK";
    public float forceUp;
    public float cooldown = 0f;
    private float initCooldown;
    public float getAtk;
    public bool attacked = false;
    private float damageMultiplier = 1.0f;


    // Use this for initialization
    void Start () {
        atkcl = GetComponentInChildren<Collider>();
        initCooldown = cooldown;
	}
    void OnTriggerEnter(Collider atkcl)
    {
            if (atkcl.tag == "Player")
        {
            Vector3 direction = transform.forward.normalized;
            atkcl.attachedRigidbody.AddForce(direction.x * baseKnockback*damageMultiplier, forceUp, direction.z * baseKnockback*damageMultiplier);
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
