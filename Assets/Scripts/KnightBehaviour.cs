using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightBehaviour : MonoBehaviour
{

    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isAlive", false);
        }

        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("isWalking", true);
        }
        else 
        {
            animator.SetBool("isWalking", false);
        }
          */
    }
}
