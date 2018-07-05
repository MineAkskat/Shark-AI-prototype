using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;

public class obstrucleAvoider : MonoBehaviour {
    bool forward = true;
    public int speed;
    Rigidbody rb;
    Vector3 playerInitialPos;
    bool up=false;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        playerInitialPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (forward)
        {
            Vector3 playerPos = gameObject.transform.position;
            rb.MovePosition(playerPos + Vector3.right/speed);

        }
        if (up == true && gameObject.transform.position.z != playerInitialPos.z)
        {
            Vector3 playerPos = gameObject.transform.position;
            rb.MovePosition(playerPos + Vector3.forward);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("obstrucle"))
        {

            forward = false;
            Vector3 playerPos = gameObject.transform.position;
            rb.MovePosition(playerPos - Vector3.forward / 2);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "obstrucle")
        {
            Vector3 obstruclePos = other.gameObject.transform.position;
            forward = true;
            rb.useGravity = true;
        }
    }
}
