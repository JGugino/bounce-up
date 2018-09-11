using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour {

    public static DistanceTracker instance;

    public GameObject levelGround, ball;

    public TextMeshProUGUI distanceText, highestText;

    private float playerDistance = 0, highestDistance = 0;

    private void Awake()
    {
        instance = this;
    }

	void Update () {

        playerDistance = Mathf.Round(ball.transform.position.y - levelGround.transform.position.y);

        distanceText.text = playerDistance.ToString();

        if (highestDistance < playerDistance)
        {
            highestDistance = playerDistance;

            highestText.text = highestDistance.ToString();
        }
    }

    public float getDistance()
    {
        return playerDistance;
    }

    public float getHighestDistance()
    {
        return highestDistance;
    }
}
