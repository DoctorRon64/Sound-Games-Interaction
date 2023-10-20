using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;
    public Rigidbody rb2d;
    private GameObject myObject;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody>();
        rb2d.constraints = RigidbodyConstraints.FreezeRotation;
        rb2d.useGravity = false;
        myObject = gameObject;
    }

    void Update()
    {
        attractor.Attract(myObject);
    }
}
