﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public Collider groundCollider;
    public float speed;
    public float jumpForce;
    public string hAxis;
    public string vAxis;    
    public string jumpAxis;
    public bool onGround;


    public AudioClip jumpClip;
    public AudioClip hitGroundClip;

    public GameObject deadPlayerPrefab;

    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GetComponent<AudioSource>().PlayOneShot(hitGroundClip);
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider groundCollider)
    {
        if (groundCollider.tag == "killBox")
        {
            GameObject deadRobot = Instantiate(deadPlayerPrefab, transform.position, transform.rotation);
            deadRobot.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider groundCollider)
    {
        if (groundCollider.tag == "Ground")
        {
            onGround = false;
        }
    }
    // Update is called once per frame
    void Update() {
        float hSpeed = Input.GetAxis(hAxis);
        float vSpeed = Input.GetAxis(vAxis);
        float jump = Input.GetAxis(jumpAxis);
        Vector3 dis = new Vector3(hSpeed, 0, vSpeed);
        rb.AddForce(dis.normalized * speed*Time.deltaTime);
        float yRot = (Mathf.Atan2(dis.x, dis.z) / 3.14f * 180);
        if (Mathf.Abs(hSpeed)>.1||Mathf.Abs(vSpeed)>.1) { 
        transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        if (onGround&&jump>0)
        {
            rb.AddForce(new Vector3(0, jump, 0) * jumpForce);
            GetComponentInChildren<AudioSource>().PlayOneShot(jumpClip);
            onGround = false;
        }
        
    }
}
