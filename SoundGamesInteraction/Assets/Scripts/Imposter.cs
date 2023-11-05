using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Imposter : Creature
{
    private bool Activated = false;
    private float Speed = 10f;
    public float FollowDistance = 1f;

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
        if (Input.GetKeyDown(keyCode) && CreatureType == CreatureTypeEnum.Imposter)
        {
            Activated = true;
        }
    }

    private void Update()
    {
        if (target != null && Activated)
        {
            Vector3 direction = target.position - transform.position;

            float distance = direction.magnitude;
            if (distance > FollowDistance)
            {
                direction.Normalize();
                transform.position += direction * (distance - FollowDistance) * Speed * Time.deltaTime;
            }
        }
    }
}
