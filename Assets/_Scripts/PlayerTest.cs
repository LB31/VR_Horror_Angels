using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour {
    public float speed, rotationSpeed;
    public Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {
        Movement();
	}

    void Movement(){
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);
    }
}
