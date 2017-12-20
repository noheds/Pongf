using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float ConstraintsY = 2.25f;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        var vel = rb.velocity;

        if(Input.GetKey(moveUp)){
            vel.y = speed;
            Debug.Log("Up");
        }
        else if (Input.GetKey(moveDown)){
            vel.y = -speed;
            Debug.Log("Down");
        }
        else if (!Input.anyKey){
            vel.y = 0;
            Debug.Log("Nothing");
        }
        rb.velocity = vel;

        var pos = transform.position;

        if (pos.y > ConstraintsY){
            pos.y = ConstraintsY;
            Debug.Log("UpperContraint");
        }
        else if (pos.y < -ConstraintsY){
            pos.y = -ConstraintsY;
            Debug.Log("LowerConstraint");
        }
        transform.position = pos;

    }
}
