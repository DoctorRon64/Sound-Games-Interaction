using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public  enum CreatureTypeEnum
    {
        Real,
        Imposter
    }
    public CreatureTypeEnum CreatureType;

    [SerializeField] protected AudioClip audioClip;
    [SerializeField] protected float MinDistance;
    [SerializeField] protected float MaxDistance;

    protected CreatureManager creatureManager;
    protected static KeyCode keyCode = KeyCode.Space;
    protected AudioSource source;

    public void Setup(CreatureManager _creatureManager)
    {
        creatureManager = _creatureManager;
    }
}
