using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerMotion : MonoBehaviour
{
    Animator animator;
    bool isDrawerClosed;
    public GameObject Crosshair;
    public GameObject CrosshairTouch;
    public GameObject aCamera;
    bool isTriggerHit;
    // Start is called before the first frame update
    void Start()
    {
        //  animator = this.gameObject.transform.parent.GetComponent<Animator>();
        animator = this.gameObject.GetComponent<Animator>();
        isDrawerClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //raycast forward from main camera
        if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
        {
            if (hit.transform.gameObject.name == this.gameObject.name && hit.distance < 8 && hit.transform.gameObject.tag == "Drawer")
            {
                if (!isTriggerHit)
                {
                    isTriggerHit = true;
                    Crosshair.SetActive(false);
                    CrosshairTouch.SetActive(true);
                    
                }


                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("open", isDrawerClosed);
                    isDrawerClosed = !isDrawerClosed;
                }
            }
            else
            {
                if(isTriggerHit)
                {
                    isTriggerHit = false;
                    Crosshair.SetActive(true);
                    CrosshairTouch.SetActive(false);
                }
                
            }
        }
    }

    /*private void OnMouseDown()
    {
        animator.SetBool("open", isDrawerClosed);
        isDrawerClosed = !isDrawerClosed;
       
    }*/
}
