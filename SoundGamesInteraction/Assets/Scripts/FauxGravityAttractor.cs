using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public const float gravity = -10f;

    public void Attract(GameObject _body)
    {
        Vector3 _gravityUp = (_body.transform.position - transform.position).normalized;
        Vector3 _bodyUp = _body.transform.up;
        _body.GetComponent<Rigidbody>().AddForce(_gravityUp * gravity);
        Quaternion _targetRotation = Quaternion.FromToRotation(_bodyUp, _gravityUp) * _body.transform.rotation;
        _body.transform.rotation = Quaternion.Slerp(_body.transform.rotation, _targetRotation, 50 * Time.deltaTime);
    }
}
