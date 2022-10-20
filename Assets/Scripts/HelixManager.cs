using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringsDistance = 5;

    public int noOfRings;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize number of rings based on the level
        noOfRings = GameManager.currentLevelIndex + 5;

        // Spawn helix rings
        for (int i = 0; i < noOfRings; i++)
        {
            if (i == 0)
                SpawnRing(0);
            else
                SpawnRing(Random.Range(1, helixRings.Length - 1));
        }

        // Spawn the last ring
        SpawnRing(helixRings.Length - 1);
    }


    public void SpawnRing(int ringIndex)
    {
        GameObject gameRings = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        gameRings.transform.parent = transform;
        ySpawn -= ringsDistance;
    }
}
