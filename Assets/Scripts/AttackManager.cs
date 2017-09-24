using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public float baseKnockback = 1.0f;
    public Collider atkcl;
    private ParticleSystem attackParticleSystem;
    public string attackAxis = "ATK";
    public float forceUp;
    public float cooldown = 0f;
    private float initCooldown;
    private float getAtk;
    private bool attacked = false;
    public float damageMultiplier = 1.0f;
    public float damageDecayPercent = 0f;

    public AudioClip attackClip;


    // Use this for initialization
    void Start () {
        atkcl = GetComponentInChildren<Collider>();
        attackParticleSystem = GetComponentInChildren<ParticleSystem>();
        initCooldown = cooldown;
	}
    void OnTriggerEnter(Collider atkcl)
    {
            if (atkcl.tag == "Player")
        {
            Vector3 direction = transform.forward.normalized;
            atkcl.attachedRigidbody.AddForce(direction.x * baseKnockback*damageMultiplier, forceUp, direction.z * baseKnockback*damageMultiplier);
            attacked = true;
            damageMultiplier *= 1.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        getAtk = Input.GetAxis(attackAxis);

        if (atkcl.enabled && cooldown < 0f)
        {
            atkcl.enabled = false;
            cooldown = initCooldown;
            attacked = false;
        }

        if (getAtk > 0 && cooldown < 0f)
        {
            atkcl.enabled = true;
            attackParticleSystem.Emit(100);
            GetComponentInParent<AudioSource>().PlayOneShot(attackClip);
            cooldown = initCooldown;
        }
        if (damageMultiplier > 1)
            damageMultiplier -= (damageMultiplier * damageDecayPercent * Time.deltaTime);
        if (damageMultiplier < 1)
            damageMultiplier = 1;
    }
    public float getDamageMultiplier()
    {
        return damageMultiplier;
    }
}
