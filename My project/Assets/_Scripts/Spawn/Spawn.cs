using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] GameObject enemy;

    private float[] delays ={.75f, 2.0f,
                             0.5f, 1.5f,
                             .25f, 0.5f,
                             .10f, .25f};
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
        var phase = GlobalVariables.phase;
       
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity, transform);

        Invoke(nameof(SpawnObjects), Random.Range(delays[phase], delays[phase +1]));
    }
}
