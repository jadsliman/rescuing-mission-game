using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PWeapon : MonoBehaviour
{
    public Sprite Icon;
    public Image i;
    public string Name;
    public int level = 1;
    public int upgradeCost, ID;
    public bool isUsed = false;
    public string lvl1, lvl2, lvl3;

    public void Start()
    {
        i = GetComponent<Image>();
        upgradeCost = 1000;
    }

    public void Upgrade()
    {
        if(level != 3)
        {
            level++;
            upgradeCost = 3000; //example for now
        }
    }
}
