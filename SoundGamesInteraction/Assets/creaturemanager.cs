using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class creaturemanager : MonoBehaviour
{
    public int CreatureAmount;
    public List<Creature> creatures = new List<Creature>();

    private void Awake()
    {
        CreatureAmount = 0;
    }

    private void Update()
    {
        
    }
}
