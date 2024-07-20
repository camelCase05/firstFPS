using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier;
    public float aimMultiplier;

    public Transform gun;

    public int gravity;
    public int jumpVelocity;
    bool isGrounded;
    public LayerMask mask;

    float currentVelocity;
    float speed;

    Vector3 gunPosition;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        currentVelocity = 0;
        isGrounded = true;

        speedMultiplier *= moveSpeed;
        aimMultiplier *= moveSpeed;

        gunPosition = gun.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.5f, mask);

        if (!isGrounded)
        {
            currentVelocity -= gravity * Time.deltaTime;
        }
        else
        {
            currentVelocity = 0;
        }

        
        if (Input.GetMouseButton(1))
        {
            speed = aimMultiplier;
            gun.localPosition = new Vector3(0f, gunPosition.y, gunPosition.z);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedMultiplier;
        }
        else
        {
            gun.localPosition = gunPosition;
            speed = moveSpeed;
        }

        if (Input.GetKey(KeyCode.W) && Mathf.Abs((transform.position + transform.forward).x) < 25f && Mathf.Abs((transform.position + transform.forward).z) < 25f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Mathf.Abs((transform.position - transform.forward).x) < 25f && Mathf.Abs((transform.position - transform.forward).z) < 25f)
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && Mathf.Abs((transform.position + transform.right).x) < 25f && Mathf.Abs((transform.position + transform.right).z) < 25f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Mathf.Abs((transform.position - transform.right).x) < 25f && Mathf.Abs((transform.position - transform.right).z) < 25f)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            currentVelocity += jumpVelocity;
            isGrounded = false;
        }

        transform.position += Vector3.up * currentVelocity * Time.deltaTime;
    }
}
