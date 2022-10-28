using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endsound : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();   
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
