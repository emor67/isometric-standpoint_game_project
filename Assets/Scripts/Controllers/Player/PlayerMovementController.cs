using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.ValueObjects;
using System;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private bool _isReadyToMove;

    private Rigidbody rb;
    private float horizontal, vertical;

    private PlayerMovementData _data;

    private Vector3 _playerMovementInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    internal void SetData(PlayerMovementData movementData)
    {
        _data = movementData;
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * Time.fixedDeltaTime * _data.MovementSpeed;
        rb.MovePosition(transform.position + movement);

        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, _data.TurnSpeed * Time.deltaTime);
        }
    }

    private void StopPlayer()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void GetMovementInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerMovablityCheck();
        GetMovementInput();
    }

    void PlayerMovablityCheck()
    {
        if (!_isReadyToMove)
        {
            StopPlayer();
            return;
        }

        if (_isReadyToMove)
        {
            MovePlayer();
        }

    }

    //Diagonal limitation for pushable puzzle object 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pushable"))
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRb)
            {
                Vector3 pushDirection = collision.contacts[0].point - transform.position;
                pushDirection.y = 0f;

                // Check if the push direction is primarily along the X or Z axis
                if (Mathf.Abs(pushDirection.z) > Mathf.Abs(pushDirection.x))
                {
                    pushDirection.z = 0f;
                    otherRb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
                }
                else
                {
                    pushDirection.x = 0f;
                    otherRb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                }

                otherRb.AddForce(pushDirection.normalized * _data.PushForce, ForceMode.Impulse);
            }
        }
    }
}

