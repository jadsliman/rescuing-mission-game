using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PGadget : MonoBehaviour
{
    public Sprite Icon;
    public Image i;
    public string Name, lvl = "Normal";
    public int level = 1;
    public int upgradeCost, ID;
    public bool isUsed = false;
    public string NL, EL;

    public void Start()
    {
        i = GetComponent<Image>();
        upgradeCost = 5;
    }

    public void Upgrade()
    {
        if(level != 2)
        {
            lvl = "Evoluted";
            level = 2;
        }
    }
}
