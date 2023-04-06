using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public GameObject player;
    public float visionDistance = 10f;
    private NavMeshAgent navAgent;
    private Vector3 startPosition;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
    }

    private void Update()
    {
        // Check if the player is within the enemy's line of sight
        if (CanSeePlayer())
        {
            // Set the destination of the NavMeshAgent to the position of the player
            navAgent.SetDestination(player.transform.position);
        }
        else
        {
            // Set the destination of the NavMeshAgent back to the starting position
            navAgent.SetDestination(startPosition);
        }
    }

    private bool CanSeePlayer()
    {
        // Check if the player is within the vision distance of the enemy
        if (Vector3.Distance(transform.position, player.transform.position) <= visionDistance)
        {
            // Check if there are any obstacles between the enemy and the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    // The player is in line of sight
                    return true;
                }
            }
        }

        // The player is not in line of sight
        return false;
    }
}

