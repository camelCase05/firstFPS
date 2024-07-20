using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumEnemy : MonoBehaviour
{
    Transform player;
    float maxHealth = 200f;
    float health;
    float speed;
    float monsterDamage;
    float attackSpeed;

    float timer = 0;

    int leftRight;
    float prevHealth;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        health = maxHealth;
        speed = 5f;
        monsterDamage = 15f;
        attackSpeed = 1.5f;
        leftRight = 1;
        prevHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        transform.LookAt(player);

        slider.value = health / maxHealth;
        transform.GetChild(0).LookAt(Camera.main.transform);

        if (Mathf.Abs(Vector3.Dot(player.forward.normalized, dirToPlayer.normalized)) >= 0.7f && dirToPlayer.magnitude > 3f)
        {
            if (prevHealth != health)
            {
                leftRight *= -1;
                prevHealth = health;
            }
            dirToPlayer = (new Vector3(dirToPlayer.x, 0, dirToPlayer.z)).normalized + (transform.right * 0.6f * leftRight);
            transform.position += dirToPlayer * speed * Time.deltaTime;
            timer += Time.deltaTime;
        }
        else if (dirToPlayer.magnitude > 1.3f)
        {
            dirToPlayer = new Vector3(dirToPlayer.x, 0, dirToPlayer.z).normalized;
            transform.position += dirToPlayer * speed * Time.deltaTime;
            timer += Time.deltaTime;
        }
        else
        {
            if (timer == 0 || timer > attackSpeed)
            {
                player.gameObject.GetComponent<PlayerHealth>().loseHealth(monsterDamage);
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public Transform getPlayer()
    {
        return player;
    }
}
