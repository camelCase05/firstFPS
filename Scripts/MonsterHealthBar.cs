using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealthBar : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.parent.LookAt(transform.parent.parent.GetComponent<EasyMonster>().getPlayer());
        transform.parent.LookAt(Camera.main.transform);
        slider.value = transform.parent.parent.GetComponent<EasyMonster>().healthBar();
    }
}
