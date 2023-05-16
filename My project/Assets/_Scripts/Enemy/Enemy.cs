using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3;

    public float Speed { get { speed *= 2; return speed; } private set => speed = value; }

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        speed = GlobalVariables.CarSpeed;
        transform.Translate(-transform.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovent player))
        {
            player.Die();
        }
    }
}
