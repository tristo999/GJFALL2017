using System.Collections;
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
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider groundCollider)
    {
        if (groundCollider.tag == "Ground")
        {
            onGround = true;
        }
        if (groundCollider.tag == "killBox")
        {
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
        Debug.Log(hSpeed + "," + vSpeed);

        float jump = Input.GetAxis(jumpAxis);
        Vector3 dis = new Vector3(hSpeed, 0, vSpeed);
        rb.AddForce(dis.normalized * speed*Time.deltaTime);
        float yRot = (Mathf.Atan2(dis.x, dis.z) / 3.14f * 180);
        if (Mathf.Abs(hSpeed)>.1||Mathf.Abs(vSpeed)>.1) { 
        transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        if (onGround)
        {
            rb.AddForce(new Vector3(0, jump, 0) * jumpForce * Time.deltaTime);
        }
    }
}
