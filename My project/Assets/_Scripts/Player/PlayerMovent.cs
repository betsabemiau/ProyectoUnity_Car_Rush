using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    Touch touch;
    Vector3 playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            playerPos = Camera.main.ScreenToWorldPoint(touch.position);

            playerPos.x = Mathf.Clamp(playerPos.x, -4, 4);
        }
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerPos.x, -3.25f), Time.deltaTime * 10f);
    }

    public void Die()
    {
        print("Ola");
    }
}
