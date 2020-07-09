using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!isAlive)
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }
        
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            //if (distanceToTarget >= chaseRange)
            // {

                //GetComponent<Animator>().SetTrigger("Idle");
                //GetComponent<Animator>().SetTrigger("Move");
                //isProvoked = false;
            //}
            //else
            //{
                EngageTarget();
            //}
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
        
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            //chase
            ChaseTarget();
            GetComponent<Animator>().SetBool("Attack", false);

        }
        else if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            //attack

            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    public void Die()
    {
        isAlive = false;
    }

}
