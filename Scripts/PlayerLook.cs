using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.parent.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -1 * rotateSpeed);
        }
    }
}
