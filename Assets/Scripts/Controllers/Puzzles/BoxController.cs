using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Transform targetArea; // Assign the target area in the Inspector

    private bool isBoxInPlace = false;
    private Rigidbody boxRigidbody; // Reference to the box's rigidbody component

    private void Start()
    {
        boxRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the box is in the correct position
        if (!isBoxInPlace && Vector3.Distance(transform.position, targetArea.position) < 0.1f)
        {
            isBoxInPlace = true;
            StopBox(); // Call the method to stop the box
            TriggerAction(); // Call the method to trigger the action
        }
    }

    private void StopBox()
    {
        // Stop the box's movement
        boxRigidbody.isKinematic = true;
        boxRigidbody.velocity = Vector3.zero;
        boxRigidbody.angularVelocity = Vector3.zero;
    }

    private void TriggerAction()
    {
        // Implement your desired action here
        Debug.Log("Box is in the correct position!");
        // You can add your code here to open doors, activate mechanisms, or display messages.
    }
}
