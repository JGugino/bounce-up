using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public bool isPC = false;

    [SerializeField]
    private float bounceForce = 2.4f, moveSpeed = 1f, speedMultiplier = 0.5f, bounceMultiplier = 0.5f;

    [SerializeField]
    private int maxJumps = 1, jumpsLeft = 0;

    private Rigidbody ballRB;

    private bool hasHighJump = false, hasFastMove = false;

    private void Awake()
    {
        jumpsLeft = maxJumps;

        ballRB = GetComponent<Rigidbody>();

        LoadingManager.instance.loadHighscore();
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

            ballMove(direction.x);

        }else if (isPC)
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                PlayerPrefs.DeleteAll();
                Debug.LogWarning("PLAYER PREFS HAS BEEN DELETED!");
            }

            if (Input.GetButtonDown("Jump"))
            {
                if ((jumpsLeft > 0))
                {
                    ballJump();
                }
            }

            float direction = Input.GetAxis("Horizontal");

            ballMove(direction);
        }
	}

    private void ballMove(float _direction)
    {
        if (!hasFastMove)
        {
            ballRB.AddForce(new Vector3(_direction * moveSpeed, 0, 0));
        }
        else if (hasFastMove)
        {
            ballRB.AddForce(new Vector3((_direction * moveSpeed) * speedMultiplier, 0, 0));
        }
    }

    private void ballJump()
    {
        if ((jumpsLeft > 0))
        {
            jumpsLeft--;

            if (!hasHighJump)
            {
                ballRB.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }else if (hasHighJump)
            {
                ballRB.AddForce((Vector3.up * bounceForce) * bounceMultiplier, ForceMode.Impulse);
            }
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

    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.tag;

        switch (otherTag)
        {
           case "Double Jump":
                GUIManager.instance.showDoubleJump();
                maxJumps = 2;
                jumpsLeft = maxJumps;
                StartCoroutine(activatePowerUp(otherTag, 35));
            break;

            case "High Jump":
                GUIManager.instance.showHighJump();
                hasHighJump = true;
                StartCoroutine(activatePowerUp(otherTag, 35));
                break;

            case "Fast Move":
                GUIManager.instance.showFastMove();
                hasFastMove = true;
                StartCoroutine(activatePowerUp(otherTag, 35));
                break;

            default:
                Debug.Log("Don't know what to do with object with tag of " + otherTag);
                break;
        }
    }

    IEnumerator activatePowerUp(string _name, int _length)
    {
        yield return new WaitForSeconds(_length);

        switch (_name)
        {
            case "Double Jump":
                GUIManager.instance.hideDoubleJump();
                maxJumps = 1;
                jumpsLeft = maxJumps;
                break;

            case "High Jump":
                GUIManager.instance.hideHighJump();
                hasHighJump = false;
                break;

            case "Fast Move":
                GUIManager.instance.hideFastMove();
                hasFastMove = false;
                break;
        }
    }
}
