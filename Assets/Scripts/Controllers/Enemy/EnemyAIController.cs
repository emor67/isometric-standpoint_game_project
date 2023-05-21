using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{    
    private float _visionDistance = 13f;
    
    private NavMeshAgent _navAgent;
    
    private bool _knockback = false;
    private float _knockbackMultipliar = 8f;
    
    private Vector3 _startPosition;
    private Vector3 _direction;

    public GameObject player;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        DecideDestination();
        ApplyKnockback();
    }

    private void ApplyKnockback()
    {
        //Knocks the enemy back when appropriate 
        if (_knockback)
        {
            _navAgent.velocity = _direction * _knockbackMultipliar;
        }
    }

    private void DecideDestination()
    {
        // Check if the player is within the enemy's line of sight
        if (CanSeePlayer())
        {
            _navAgent.SetDestination(player.transform.position);
        }
        else
        {
            _navAgent.SetDestination(_startPosition);
        }
    }

    private bool CanSeePlayer()
    {
        // Check if the player is within the vision distance of the enemy
        if (Vector3.Distance(transform.position, player.transform.position) <= _visionDistance)
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
        _knockback = true;
        _navAgent.speed = 10f;
        _navAgent.angularSpeed = 0f;
        _navAgent.acceleration = 20f;

        yield return new WaitForSeconds(0.2f);   

        //Reset to default values
        _knockback = false;
        _navAgent.speed = 3.8f;
        _navAgent.angularSpeed = 180f;
        _navAgent.acceleration = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        _direction = other.transform.forward; //Always knocks enemy in the direction the main character is facing
       
        if (other.gameObject.CompareTag("PlayerSword"))
        {
            StartCoroutine(KnockBack());
        }
    }
}

