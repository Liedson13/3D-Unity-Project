using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  public float maxspeed = 1.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool IsOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;



        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxspeed) + (transform.right * Input.GetAxis("Horizontal") * maxspeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        Debug.Log(Input.GetAxis("Vertical"));

        rotation = rotation + Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y");
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
    }
}
