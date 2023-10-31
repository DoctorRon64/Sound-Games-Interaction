using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Imposter : Creature
{
    private bool Activated = false;

    public PlayerController player;
    public Transform target;

    private void Awake()
    {
        CreatureType = CreatureTypeEnum.Imposter;

        player = FindObjectOfType<PlayerController>();
        target = player.transform;

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
            Activated = true;
        }
    }

    private void Update()
    {
        if (target != null && Activated)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            transform.position += direction * 5f * Time.deltaTime;
        }
    }
}
