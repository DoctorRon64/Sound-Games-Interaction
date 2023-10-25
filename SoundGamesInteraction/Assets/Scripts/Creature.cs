using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    public enum CreatureTypeEnum
    {
        Animal,
        Imposter
    }
    public CreatureTypeEnum CreatureType;

    private bool isCaptured = false;
    [SerializeField] private KeyCode keyCode = KeyCode.Space;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("collide");

        if (Input.GetKey(keyCode))
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
