using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    readonly float speed = 5;
    private void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
    }
}
