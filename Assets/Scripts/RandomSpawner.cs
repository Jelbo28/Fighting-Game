using UnityEngine;
using System.Collections;
using System;

public class RandomSpawner : MonoBehaviour
{
    //public PlayerHealth playerhealth;
    public GameObject HealthPackage;
    public float spawnTime = 10f;
    public Transform[] spawnPoints;
   
    
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        /*    if (playerHealth.currentHealth <= 0f)
            {
                return;
            }   */

        int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

        Instantiate(HealthPackage, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }   
}
