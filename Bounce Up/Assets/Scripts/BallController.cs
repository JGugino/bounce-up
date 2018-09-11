using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public bool isPC = false;

    [SerializeField]
    private float bounceForce = 0.5f, moveSpeed = 0.5f;

    [SerializeField]
    private int playerTotalDistance= 0, maxJumps = 1, jumpsLeft = 0;

    private Rigidbody ballRB;

    private void Awake()
    {
        jumpsLeft = maxJumps;

        ballRB = GetComponent<Rigidbody>();
    }

    void Update () {
        if (!isPC)
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {

                if (jumpsLeft > 0)
                {
                    ballJump();
                }
            }

            Vector3 direction = Input.acceleration;

            ballRB.AddForce(new Vector3(direction.x * moveSpeed, 0, 0));

        }else if (isPC)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if ((jumpsLeft > 0))
                {
                    ballJump();
                }
            }
        }
	}

    private void ballJump()
    {
        if ((jumpsLeft > 0))
        {
            jumpsLeft--;

            ballRB.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string otherTag= collision.collider.tag;

        if (otherTag == "Ground")
        {
            jumpsLeft = maxJumps;

        }
    }
}
