using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawner : MonoBehaviour
{
    public GameObject[] myZombies;
    public Vector3[] spawnPoints;
    public float currentTime;
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            currentTime = 4f;
            int randomIndex = Random.Range(0, myZombies.Length);
            int randomIndexPos = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < 3; i++)
                Instantiate(myZombies[i], spawnPoints[randomIndexPos], Quaternion.identity);
            return;
        }
    }
}