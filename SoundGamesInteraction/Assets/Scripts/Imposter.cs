using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Imposter : Creature
{
    private NavMeshAgent agent;

    private void Awake()
    {
        CreatureType = CreatureTypeEnum.Imposter;
        agent = GetComponent<NavMeshAgent>();

        source = GetComponent<AudioSource>();
        source.clip = audioClip;
        source.minDistance = MinDistance;
        source.maxDistance = MaxDistance;
        source.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(keyCode) && CreatureType == CreatureTypeEnum.Imposter)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Debug.Log("follow");
    }
}
