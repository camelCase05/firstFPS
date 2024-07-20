using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    public float regenHealth;
    float health;
    public float limit;
    public float timer;
    public GameObject gameOverPanel;
    float threeSecWaiter = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = limit + 1;
        health = fullHealth;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= limit)
        {
            if (timer < 0)
            {
                if (health < fullHealth)
                {
                    health += regenHealth;
                }
                else
                {
                    health = fullHealth;
                    timer = limit + 1;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (health <= 0)
        {
            threeSecWaiter += Time.deltaTime;
            if (!gameOverPanel.activeSelf && threeSecWaiter >= 3f)
            {
                gameOverPanel.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.None;
            timer = limit + 1;
            Camera cam = Camera.main;
            cam.transform.GetComponent<PlayerLook>().enabled = false;
            cam.transform.parent = null;
            cam.transform.DetachChildren();
            if (Vector3.Magnitude(cam.transform.position - transform.position) < 5f)
            {
                cam.transform.position += (new Vector3(3f, 3f, 3f)).normalized * 1.5f * Time.deltaTime;
            }
            cam.transform.LookAt(transform);
            transform.GetComponent<PlayerMove>().enabled = false;
            
            //show panel
            //if click restart
                //reload level
                //panel hide
            //if click quit
                //stop level
        }
    }

    public void loseHealth(float damage)
    {
        health -= damage;
        timer = limit;
    }

    public float healthBar()
    {
        return health / fullHealth;
    }
}
