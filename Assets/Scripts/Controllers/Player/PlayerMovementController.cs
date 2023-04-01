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
       
        //Right now PlayerData scriptable has some issue and this is the evidence for devs
        /*if (_data.MovementSpeed > 0)
        {
            Debug.LogError("MyScriptableObject reference is null!");
            return;
        }*/
    }
    internal void SetData(PlayerMovementData movementData)
    {
        _data = movementData;
    }

    private void MovePlayer()
    {
        //Temporary variables will be changed with PlayerData scriptable object when it.
        //float speed = 5;
        //float turnSpeed = 10;
        //

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

}
