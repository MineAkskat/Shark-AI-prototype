using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {
    public int jumpValue;
   public bool Jump=true;
  public  bool grounded;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Jump = true;

	}
	
	// Update is called once per frame
	void Update () {
        if (Jump == true && grounded == true)
        {
            Vector3 playerPos = gameObject.transform.position;
            transform.Translate(0f, 500 * Time.deltaTime, 0f);

            Jump = false;
            grounded = false;


            StartCoroutine(Wait(3));
        }
        
	}
    IEnumerator Wait(int time)
    {
        Jump = false;   
        yield  return new WaitForSeconds(time);
        Jump = true;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
