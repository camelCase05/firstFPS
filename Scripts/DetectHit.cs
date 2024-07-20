using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour
{
    public Camera cam;
    public Image crosshair;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //gunshot sound

                if (hit.collider.tag == "Enemy")
                {
                    crosshair.color = Color.red;
                    if (hit.collider.gameObject.GetComponent<EasyMonster>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EasyMonster>().takeDamage(30);
                    }
                    else if (hit.collider.gameObject.GetComponent<MediumEnemy>() != null)
                    {
                        hit.collider.gameObject.GetComponent<MediumEnemy>().takeDamage(30);
                    }
                }
            }
            else if (hit.collider.tag == "Enemy")
            {
                crosshair.color = Color.cyan;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
        else
        {
            crosshair.color = Color.white;

            if (Input.GetMouseButton(0))
            {
                //gunshot sound
            }
        }
    }
}
