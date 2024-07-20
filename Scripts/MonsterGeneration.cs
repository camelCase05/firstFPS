using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGeneration : MonoBehaviour
{
    public int startMonsters;
    int numMonsters;
    public GameObject monster;
    public Transform player;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        numMonsters = startMonsters;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < numMonsters)
        {
            Vector3 instancePos = new Vector3(-20 + (Random.value * 40), 0.45f, -20 + (Random.value * 40));

            if(Vector3.Magnitude(player.position - instancePos) >= 5f)
            {
                Instantiate(monster, instancePos, Quaternion.identity, this.transform);
            }
        }

        time += Time.deltaTime;
        numMonsters = startMonsters + (int)(time / 15);
    }
}
