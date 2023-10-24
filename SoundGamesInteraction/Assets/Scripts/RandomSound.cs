using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    AudioSource source = null;
    private int pause = 2000;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.frameCount%pause == 0)
        {
            float random = Random.Range(0.9f, 1.1f);
            source.pitch = random;
        }
    }
}
