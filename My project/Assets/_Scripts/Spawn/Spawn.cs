using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnObjects), Random.Range(.5f, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjects()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity, transform);

        Invoke(nameof(SpawnObjects), Random.Range(.75f, 2));
    }
}
