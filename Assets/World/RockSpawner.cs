using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // This class handles the spawning of rocks as children of the track, to make the rocks move towards the player
     
    // List which includes all the rock prefab variations 
    private List<GameObject> rockPrefabs = new List<GameObject>();

    // Transform of the track
    private Transform track;

    // Floats for the spawnOffset
    private float x_range;
    private float y_range;
    private float z_range;

    // Vector3 offset to manage the position of the spawnpoint
    private Vector3 spawnOffset;

    // A spawn intervalle and timer to prevent spawning all the rocks at once
    float spawnIntervalle = 0.4f;
    float timer;

    private void Start()
    {
        // Add the rock variations from the Resources directory to the list
        rockPrefabs.Add(Resources.Load<GameObject>("Rocks/rock_01"));
        rockPrefabs.Add(Resources.Load<GameObject>("Rocks/rock_02"));
        rockPrefabs.Add(Resources.Load<GameObject>("Rocks/rock_03"));

        // Reference the tracks Transform via its tag
        track = GameObject.FindWithTag("Track").GetComponent<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // When the timer reaches the spawn intervalle, the method SpawnRock() is called
        if (timer > spawnIntervalle)
        {
            SpawnRock();
        }
    }

    private void SpawnRock()
    {
        // Random values in a fitting range
        x_range = Random.Range(-49f, -44f);
        y_range = Random.Range(-7f, 7f);
        z_range = Random.Range(25f, 30f);
        
        // Offset with random values for the spawnpoint
        spawnOffset = new Vector3(x_range, y_range, z_range);

        // Instantiate a random rock prefab as child of the track
        Instantiate(rockPrefabs[Random.Range(0, rockPrefabs.Count)], track.transform.position + spawnOffset, Quaternion.identity, track);

        // Set random spawn intervalle and reset timer
        spawnIntervalle = Random.Range(0.6f, 1.5f);
        timer = 0;
    }
}
