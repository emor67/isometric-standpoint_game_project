using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public GameObject player;
    
    private float visionDistance = 13f;
    
    private NavMeshAgent navAgent;
    
    private bool knockBack = false;
    
    private Vector3 startPosition;
    private Vector3 direction;


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
            navAgent.SetDestination(player.transform.position);
        }
        else
        {
            navAgent.SetDestination(startPosition);
        }
       
        //Knocks the enemy back when appropriate 
        if (knockBack)
        {
            navAgent.velocity = direction * 8;
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
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator KnockBack()
    {
        knockBack = true;
        navAgent.speed = 10f;
        navAgent.angularSpeed = 0f;
        navAgent.acceleration = 20f;

        yield return new WaitForSeconds(0.2f);   

        //Reset to default values
        knockBack = false;
        navAgent.speed = 3.8f;
        navAgent.angularSpeed = 180f;
        navAgent.acceleration = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        direction = other.transform.forward; //Always knocks enemy in the direction the main character is facing
       
        if (other.gameObject.CompareTag("PlayerSword"))
        {
            StartCoroutine(KnockBack());
        }
    }
}

