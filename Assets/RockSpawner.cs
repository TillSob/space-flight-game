using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private List<GameObject> rockPrefabs = new List<GameObject>();
    private Transform track;
    private Vector3 spawnOffset = new Vector3(-46.5f, 2f, 27.7f);
    float spawnIntervalle = 1f;
    float timer;

    private void Start()
    {
        rockPrefabs.Add(Resources.Load<GameObject>("Rocks/rock_01"));
        track = GameObject.FindWithTag("Track").GetComponent<Transform>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnIntervalle)
        {
            spawnRock();
        }
    }

    private void spawnRock()
    {

        Instantiate(rockPrefabs[0], track.transform.position + spawnOffset, Quaternion.identity, track);
        spawnIntervalle = Random.Range(1.5f, 3.0f);
        timer = 0;
    }
}
