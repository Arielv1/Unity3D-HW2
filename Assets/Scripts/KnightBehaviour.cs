using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBehaviour : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
            
    }
}
