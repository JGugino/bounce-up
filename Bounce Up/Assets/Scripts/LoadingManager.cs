using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour {

    public static LoadingManager instance;

    private void Awake()
    {
        instance = this;
    }


    public void saveHighscore(float _highscore)
    {
        PlayerPrefs.SetInt("Highscore", (int)_highscore);
    }

    public void loadHighscore()
    {
        float distance = PlayerPrefs.GetInt("Highscore");

        Debug.Log("Prefs Distance: " + distance);

        DistanceTracker.instance.setHighestDistance(distance);
    }
}
