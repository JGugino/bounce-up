using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    public GameObject platformPrefab, wallTop, wallBottom;

    public List<GameObject> platformSpawns;

    public int maxPlatforms = 2, platformsCreated = 0;

	void Start () {
        generateLevel();
	}

    private void generateLevel()
    {
        while (platformsCreated <= maxPlatforms)
        {
            for (int i = 0; i < platformSpawns.ToArray().Length; i++)
            {
                int randPlatform = Random.Range(0, 2);

                GameObject platform = (GameObject)platformSpawns.ToArray().GetValue(randPlatform);

                GameObject platformCreated = Instantiate(platformPrefab, platform.transform);

                platformsCreated++;
            }
        }
    }
}
