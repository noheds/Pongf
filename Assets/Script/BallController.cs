using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 vel;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Invoke("MoveBall", 2);
    }

    // Update is called once per frame
    void Update() {




    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            vel.x = rb.velocity.x;
            vel.y = (rb.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 3.0f);
            rb.velocity = vel;
        }
    }

    void MoveBall() {
        //Choose Left or Right and apply force
        float rdm = Random.Range(0, 2);

        if (rdm < 1)
        {
            rb.AddForce(new Vector2(1250, 500));
        }
        else {

            rb.AddForce(new Vector2(-1250, -500));
        }


    }

    void ResetBall(){
        vel = Vector2.zero;
        rb.velocity = vel;
        transform.position = Vector2.zero;
    }

    void RestartGame(){
        ResetBall();
        Invoke("MoveBall", 1);
    }
}
