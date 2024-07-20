using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public Transform[] weapons;
    int numWeapons;
    int currentActiveWeaponIndex = 0;

    public GameObject panel;
    public Button[] buttons;
    public Button prefab;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);

        numWeapons = transform.childCount;
        weapons = new Transform[numWeapons];

        for (int i = 0; i < numWeapons; i++)
        {
            weapons[i] = transform.GetChild(i);
            weapons[i].gameObject.SetActive(false);
        }

        weapons[0].gameObject.SetActive(true);

        buttons = new Button[numWeapons];

        int startX = -190, startY = 170;

        for(int i = 0; i < numWeapons; i++)
        {
            int index = i;

            buttons[i] = Instantiate(prefab, Vector3.zero, Quaternion.identity) as Button;
            RectTransform rectTransform = buttons[i].GetComponent<RectTransform>();
            rectTransform.SetParent(panel.transform);
            rectTransform.localPosition = new Vector3(startX + (i * (125)), startY, 0);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = weapons[i].name;
            buttons[i].onClick.AddListener(() => SetWeapon(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(!panel.activeSelf);
            if (panel.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if(Input.mouseScrollDelta.y > 0)
        {
            weapons[currentActiveWeaponIndex].gameObject.SetActive(false);
            currentActiveWeaponIndex = (currentActiveWeaponIndex + 1) % numWeapons;
            weapons[currentActiveWeaponIndex].gameObject.SetActive(true);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            weapons[currentActiveWeaponIndex].gameObject.SetActive(false);
            currentActiveWeaponIndex = (((currentActiveWeaponIndex - 1) % numWeapons) + numWeapons) % numWeapons;
            weapons[currentActiveWeaponIndex].gameObject.SetActive(true);
        }
    }

    void SetWeapon(int buttonIndex)
    {
        weapons[currentActiveWeaponIndex].gameObject.SetActive(false);
        currentActiveWeaponIndex = buttonIndex;
        weapons[currentActiveWeaponIndex].gameObject.SetActive(true);
    }
}
