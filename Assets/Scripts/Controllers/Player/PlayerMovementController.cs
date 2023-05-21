using UnityEngine;
using Data.ValueObjects;
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private bool isReadyToMove;
    
    private float _horizontal, _vertical;

    private PlayerMovementData _data;

    public Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        isReadyToMove = true;
    }
    internal void SetData(PlayerMovementData movementData)
    {
        _data = movementData;
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(_horizontal, 0f, _vertical) * Time.fixedDeltaTime * _data.MovementSpeed;
        playerRigidbody.MovePosition(transform.position + movement);

        if (movement != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, _data.TurnSpeed * Time.deltaTime);
        }
    }

    private void StopPlayer()
    {
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
    }

    private void GetMovementInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerMovablityCheck();
        GetMovementInput();
    }

    private void PlayerMovablityCheck()
    {
        if (!isReadyToMove)
        {
            StopPlayer();
            return;
        }

        if (isReadyToMove)
        {
            MovePlayer();
        }

    }

    //Diagonal limitation for pushable puzzle object 
    private void OnCollisionEnter(Collision collision)
    {   
        PushableObjectCollisionChecker(collision);
    }

    private void PushableObjectCollisionChecker(Collision collision)
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

