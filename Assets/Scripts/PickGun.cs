using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerGun;
    bool isTriggerHit;
    public GameObject Crosshair;
    public GameObject CrosshairTouch;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //raycast forward from main camera
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.transform.gameObject.name == this.gameObject.name && hit.distance < 8)
            {
                if (!isTriggerHit)
                {
                    isTriggerHit = true;
                    Crosshair.SetActive(false);
                    CrosshairTouch.SetActive(true);

                }


                if (Input.GetKeyDown(KeyCode.E))
                {
                    Crosshair.SetActive(true);
                    CrosshairTouch.SetActive(false);
                    
                    PlayerGun.SetActive(true);
                    gameObject.SetActive(false);

                }
            }
            else
            {
                if (isTriggerHit)
                {
                    isTriggerHit = false;
                    Crosshair.SetActive(true);
                    CrosshairTouch.SetActive(false);
                }

            }
        }
    }
}
