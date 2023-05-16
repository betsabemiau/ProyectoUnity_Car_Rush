using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenario : MonoBehaviour
{
    [SerializeField] float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = GlobalVariables.scenarioSpeed;
        transform.Translate(transform.up * -speed * Time.deltaTime);

        if (transform.position.y < -8.5f)
        {
            transform.position = transform.position + new Vector3(0, 20.97f, 0);
        }
    }

}
