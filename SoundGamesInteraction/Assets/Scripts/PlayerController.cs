using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource CarSource;
    [SerializeField] private AudioSource CaptureSource;
    [SerializeField] private float moveSpeed = 15f;
    private Vector3 moveDir;
    private bool isCarSoundPlaying;

    private void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CaptureSource.Play();
        }

        if (moveDir.x != 0 || moveDir.y != 0 || moveDir.z != 0)
        {
            if (!isCarSoundPlaying)
            {
                CarSource.Play();
                isCarSoundPlaying = true;
            }
        } 
        else if (moveDir.x == 0 && moveDir.y == 0 && moveDir.z == 0)
        {
            CarSource.Stop();
            isCarSoundPlaying = false;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (isCarSoundPlaying && !CarSource.isPlaying)
        {
            isCarSoundPlaying = false;
        }
    }
}
