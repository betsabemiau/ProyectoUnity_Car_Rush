using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    [SerializeField] AudioSource audiofondo;
    [SerializeField] AudioClip audio4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audiofondo.isPlaying) return;

        audiofondo.clip = audio4;
        audiofondo.loop = true;
        audiofondo.Play();
        Destroy(this);
    }
}
