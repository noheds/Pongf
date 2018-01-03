using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;
	private Rigidbody2D rb;
	public float ConstraintsY = 2.25f;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();

		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null){
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}
	

		void Update () {
		
			var vel = rb.velocity;

			if (rb.position.y < target.position.y) {	
				vel.y = speed;
			} else {
			
				vel.y = -speed;
			}



			rb.velocity = vel;

			var pos = transform.position;

			if (pos.y > ConstraintsY){
				pos.y = ConstraintsY;
				Debug.Log("UpperContraintAI");
			}
			else if (pos.y < -ConstraintsY){
				pos.y = -ConstraintsY;
				Debug.Log("LowerConstraintAI");
			}
			transform.position = pos;

			

		}

		
	
}
