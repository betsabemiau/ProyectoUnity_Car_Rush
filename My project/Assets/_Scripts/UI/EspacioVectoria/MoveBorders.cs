using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBorders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = ((float)Screen.width / (float)Screen.height);

        transform.localScale = new Vector3(multiplier, 1);
    }
}
