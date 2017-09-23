using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public string hAxis;
    public string vAxis;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float hSpeed = Input.GetAxis(hAxis);
        float vSpeed = Input.GetAxis(vAxis);
        rb.AddForce(new Vector3(hSpeed, 0, vSpeed) * speed);
    }
}
