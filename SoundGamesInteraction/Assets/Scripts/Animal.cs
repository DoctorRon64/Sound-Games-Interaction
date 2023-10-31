using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : Creature
{
    public bool isCaptured = false;

    private void Awake()
    {
        CreatureType = CreatureTypeEnum.Real;
        source = GetComponent<AudioSource>();
        source.clip = audioClip;
        source.minDistance = MinDistance;
        source.maxDistance = MaxDistance;
        source.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(keyCode) && CreatureType == CreatureTypeEnum.Real)
        {
            Capture();
        } 
    }

    private void Capture()
    {
        if (!isCaptured)
        {
            gameObject.SetActive(false);
            isCaptured = true;
        }
    }
}
