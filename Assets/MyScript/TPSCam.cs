using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCam : MonoBehaviour
{
    [Header("Reference")]
    public Transform orbitMan;
    public Transform player;
    public Transform playerMan;
    public Rigidbody rb;
    public float rotateSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //rotate orientation.
        Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orbitMan.forward = viewDir.normalized;

        //rotate player man
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orbitMan.forward * verticalInput + orbitMan.right * horizontalInput;

        if (inputDir != Vector3.zero) 
            playerMan.forward = Vector3.Slerp(playerMan.forward, inputDir.normalized, Time.deltaTime * rotateSpeed);
    }
}
