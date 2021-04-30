using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{

    public GameObject playerGun;
    public GameObject MuzzlePoint;
    public GameObject target;
    private LineRenderer lr;
    private AudioSource audioSource;
    public ParticleSystem ShootingEffect;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lr = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
       // ShootingEffect = GetComponent<ParticleSystem>();
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGun.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Animator targetAnimator = hit.transform.gameObject.GetComponent<Animator>();
                    targetAnimator.CrossFade("death", 0f);
                    targetAnimator.SetBool("isAlive", false);
                    hit.transform.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                }
                target.transform.position = hit.point;
                StartCoroutine(ShowShot());
                

            }
        }
    }

    IEnumerator ShowShot()
    {
        
        lr.SetPosition(0, MuzzlePoint.transform.position);
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        audioSource.Play();
        ShootingEffect.Play();

        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
    }
}

