using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController cc;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 0.001f;
    private float rotX, rotY, dx, dz;
    private AudioSource footstepSound;
    // Start is called before the first frame update
    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LookAround();
        PlayFootstepSound();
        /*transform.SetPositionAndRotation(
                new Vector3(transform.position.x, transform.position.y, transform.position.z + speed),
                transform.rotation);*/

    }

    void LookAround()
    {
        rotX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        playerCamera.transform.localEulerAngles = new Vector3(rotX, 0, 0);
        transform.localEulerAngles = new Vector3(0, rotY, 0);
    }

    void MovePlayer()
    {
        dx = Input.GetAxis("Horizontal"); 
        dz = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(dx, 0, dz).normalized * speed * Time.deltaTime;

        // Transforms direction from local space to world space.
        direction = transform.TransformDirection(direction);

        cc.Move(direction);
    }

    void PlayFootstepSound()
    {
        if ((dx != 0f || dz != 0f) && !footstepSound.isPlaying)
        {
            footstepSound.Play();
        }
    }
}

