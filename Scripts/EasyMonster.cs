using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyMonster : MonoBehaviour
{
    Transform player;
    float maxHealth = 100f;
    float health;
    float speed;
    float monsterDamage;
    float attackSpeed;

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        health = maxHealth;
        speed = 5*0.85f;
        monsterDamage = 10f;
        attackSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = player.position - transform.position;

        if(dirToPlayer.magnitude > 1.3f)
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
            Destroy(this.gameObject); //health bar?
        }
    }

    public float healthBar()
    {
        return health/maxHealth;
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
