using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Gear_Manager : MonoBehaviour
{
    public PWeapon[] allWeapons;
    public Sprite SelectedWeaponImage;
    public PWeapon SelectedWeapon;
    public Sprite emptyW;

    public PGadget[] allGadgets;
    public Sprite[] SelectedGadgetsImages = new Sprite[2];
    public PGadget[] SelectedGadgets = new PGadget[2];

    public int gems, gadgetTokens;
    public TextMeshProUGUI Gems, GadgetTokens, description;

    public GameObject MWU, GU1, GU2, UP;
    public Button[] GButtons = new Button[12];
    public Button[] WButtons = new Button[5];
    public AudioSource au; public AudioClip click, up;

    void Start()
    {
        au.volume = DataCrosser.sfx;
        GButtons[0].onClick.AddListener(pressedGadget);
        GButtons[1].onClick.AddListener(pressedGadget2);
        GButtons[2].onClick.AddListener(pressedGadget3);
        GButtons[3].onClick.AddListener(pressedGadget4);
        GButtons[4].onClick.AddListener(pressedGadget5);
        GButtons[5].onClick.AddListener(pressedGadget6);
        GButtons[6].onClick.AddListener(pressedGadget7);
        GButtons[7].onClick.AddListener(pressedGadget8);
        GButtons[8].onClick.AddListener(pressedGadget9);
        GButtons[9].onClick.AddListener(pressedGadget10);
        GButtons[10].onClick.AddListener(pressedGadget11);
        GButtons[11].onClick.AddListener(pressedGadget12);

        WButtons[0].onClick.AddListener(pressedWeapon);
        WButtons[1].onClick.AddListener(pressedWeapon2);
        WButtons[2].onClick.AddListener(pressedWeapon3);
        WButtons[3].onClick.AddListener(pressedWeapon4);
        WButtons[4].onClick.AddListener(pressedWeapon5);

        StartCoroutine(s());
        gadgetTokens = DataCrosser.GTs;
        gems = DataCrosser.Gems;
    }

    void Update()
    {
        Gems.text = "x" + gems;
        GadgetTokens.text = "x" + gadgetTokens;
    }

    public PWeapon[] getAllWeapons()
    {
        return allWeapons;
    }
    //no need for these select voids
    /*public void SelectWeapon(PWeapon w)
    {
        SelectedWeapon = w;
        Sprite i = w.Icon;
        w.Icon = SelectedWeaponImage;
        SelectedWeaponImage = i;
    }

    public void SelectGadget1(PGadget g)
    {
        SelectedGadgets[0] = g;
        Sprite i = g.Icon;
        g.Icon = SelectedGadgets[0].Icon;
        SelectedGadgets[0].Icon = i;
    }

    public void SelectGadget2(PGadget g)
    {
        SelectedGadgets[1] = g;
        Sprite i = g.Icon;
        g.Icon = SelectedGadgets[1].Icon;
        SelectedGadgets[1].Icon = i;
    }*/

    public void UpgradeWeapon(PWeapon w)
    {
        if(gems >= w.upgradeCost)
        {
            gems -= w.upgradeCost;
            DataCrosser.Gems -= w.upgradeCost;
            w.Upgrade();
            detectWeapon(w);
            SaveManager.SaveGame();
        }
    }

    public void UpgradeGadget(PGadget g)
    {
        if (gadgetTokens >= g.upgradeCost)
        {
            gadgetTokens -= g.upgradeCost;
            DataCrosser.GTs -= g.upgradeCost;
            g.Upgrade();
            detectGadget(g);
            SaveManager.SaveGame();
        }
    }

    PGadget ClickedGadget;
    public void pressedGadget()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[0].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget2()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[1].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget3()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[2].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget4()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[3].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget5()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[4].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget6()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[5].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget7()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[6].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget8()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[7].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget9()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[8].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget10()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[9].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget11()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[10].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }
    public void pressedGadget12()
    {
        ClickedWeapon = null;
        ClickedGadget = GButtons[11].GetComponentInParent<PGadget>();
        detectGadget(ClickedGadget);
    }


    void detectGadget(PGadget g)
    {
        if (g.i.sprite == allGadgets[0].Icon)
        {
            //print nothing
            UP.SetActive(false); GU1.SetActive(false); GU2.SetActive(false); MWU.SetActive(false); description.text = " ";
        }
        else if (g.i.sprite == allGadgets[2].Icon)
        {
            //first aid kit
            g.NL = "Normal level:\nHeals you with 15 HP.";
            g.EL = "Evoluted level:\nHeals you with 30 HP.";
            description.text = allGadgets[2].Name + "\nLevel: " + allGadgets[2].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[2].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[3].Icon)
        {
            //iron shield
            g.NL = "Normal level:\nGives you 12 Shield Points.";
            g.EL = "Evoluted level:\nGives you 20 Shield Points.";
            description.text = allGadgets[3].Name + "\nLevel: " + allGadgets[3].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[3].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[4].Icon)
        {
            //fire ball
            g.NL = "Normal level:\nDeals 10 damage to the enemy.";
            g.EL = "Evoluted level:\nDeals 15 damage to the enemy.";
            description.text = allGadgets[4].Name + "\nLevel: " + allGadgets[4].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[4].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[5].Icon)
        {
            //revenge power
            g.NL = "Normal level:\nWhen you take damage from the enemy while the gadget is activated, you will deal 20% of his damage back to him. (The damage you took will not be reduced).";
            g.EL = "Evoluted level:\nNow you will deal 33% of the enemy damage.";
            description.text = allGadgets[5].Name + "\nLevel: " + allGadgets[5].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[5].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[6].Icon)
        {
            //true punishment
            g.NL = "Normal level:\nGives the enemy Double Damage.";
            g.EL = "Evoluted level:\nGives the enemy Triple Damage.";
            description.text = allGadgets[6].Name + "\nLevel: " + allGadgets[6].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[6].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[7].Icon)
        {
            //cheating try
            g.NL = "Normal level:\n5% chance of cancelling the next enemy turn.";
            g.EL = "Evoluted level:\n10% chance of cancelling the next enemy turn.";
            description.text = allGadgets[7].Name + "\nLevel: " + allGadgets[7].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[7].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[8].Icon)
        {
            //mega gift
            g.NL = "Normal level:\nGives 10 HP - 10 extra damage - 10 Shield Points.";
            g.EL = "Evoluted level:\nGives 15 HP - 15 extra damage - 15 Shield Points.";
            description.text = allGadgets[8].Name + "\nLevel: " + allGadgets[8].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[8].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[9].Icon)
        {
            //guaranteed safety
            g.NL = "Normal level:\nMakes you lose 30 HP and gain 100% shield.";
            g.EL = "Evoluted level:\nMakes you lose 20 HP and gain 100% shield.";
            description.text = allGadgets[9].Name + "\nLevel: " + allGadgets[9].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[9].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[10].Icon)
        {
            //stealing life
            g.NL = "Normal level:\nSwitches the HP with the enemy (in percentage).";
            g.EL = "Evoluted level:\nSwitches the HP with the enemy and gives you 10 extra HP.";
            description.text = allGadgets[10].Name + "\nLevel: " + allGadgets[10].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[10].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
        else if (g.i.sprite == allGadgets[11].Icon)
        {
            //chicken power
            g.NL = "Normal level:\nReduce enemy damage in the next turn by 25%.";
            g.EL = "Evoluted level:\nReduce the enemy damage in the next turn by 40%.";
            description.text = allGadgets[11].Name + "\nLevel: " + allGadgets[11].lvl + "\n\n" + g.NL + "\n\n" + g.EL;
            if (!g.isUsed)
            {
                GU1.SetActive(true); GU2.SetActive(true);
            }
            else
            {
                GU1.SetActive(false); GU2.SetActive(false);
            }
            if (allGadgets[11].level != 2)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            MWU.SetActive(false);
        }
    }

    PWeapon ClickedWeapon;
    public void pressedWeapon()
    {
        ClickedGadget = null;
        ClickedWeapon = WButtons[0].GetComponentInParent<PWeapon>();
        detectWeapon(ClickedWeapon);
    }
    public void pressedWeapon2()
    {
        ClickedGadget = null;
        ClickedWeapon = WButtons[1].GetComponentInParent<PWeapon>();
        detectWeapon(ClickedWeapon);
    }
    public void pressedWeapon3()
    {
        ClickedGadget = null;
        ClickedWeapon = WButtons[2].GetComponentInParent<PWeapon>();
        detectWeapon(ClickedWeapon);
    }
    public void pressedWeapon4()
    {
        ClickedGadget = null;
        ClickedWeapon = WButtons[3].GetComponentInParent<PWeapon>();
        detectWeapon(ClickedWeapon);
    }
    public void pressedWeapon5()
    {
        ClickedGadget = null;
        ClickedWeapon = WButtons[4].GetComponentInParent<PWeapon>();
        detectWeapon(ClickedWeapon);
    }

    void detectWeapon(PWeapon w)
    {
        if(w.i.sprite == allWeapons[0].Icon)
        {
            //natural sword
            w.lvl1 = "Level 1:\nDeals 25 damage and gives the enemy Poison (Poison effect deals 10 damage every 3 enemy turns).";
            w.lvl2 = "Level 2:\n+20% damage & +50% Poison damage.";
            w.lvl3 = "Level 3:\nPoison effect now deals damage every two enemy turns.";
            description.text = allWeapons[0].Name + "\nLevel: " + allWeapons[0].level + "\n\n" + w.lvl1 + "\n\n" + w.lvl2 + "\n\n" + w.lvl3;
            if (!w.isUsed)
            {
                MWU.SetActive(true);
            }
            else
            {
                MWU.SetActive(false);
            }
            if (allWeapons[0].level != 3)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            GU1.SetActive(false); GU2.SetActive(false);
        }
        else if(w.i.sprite == allWeapons[1].Icon)
        {
            //flaming sickle
            w.lvl1 = "Level 1:\nDeals 30 damage.";
            w.lvl2 = "Level 2:\n+33% damage.";
            w.lvl3 = "Level 3:\n+12.5% damage.";
            description.text = allWeapons[1].Name + "\nLevel: " + allWeapons[1].level + "\n\n" + w.lvl1 + "\n\n" + w.lvl2 + "\n\n" + w.lvl3;
            if (!w.isUsed)
            {
                MWU.SetActive(true);
            }
            else
            {
                MWU.SetActive(false);
            }
            if (allWeapons[1].level != 3)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            GU1.SetActive(false); GU2.SetActive(false);
        }
        else if (w.i.sprite == allWeapons[2].Icon)
        {
            //ice axe
            w.lvl1 = "Level 1:\nDeals 25 damage and reduces the enemy damage by 25%.";
            w.lvl2 = "Level 2:\n+20% damage.";
            w.lvl3 = "Level 3:\nReduces the enemy damage now by 30%.";
            description.text = allWeapons[2].Name + "\nLevel: " + allWeapons[2].level + "\n\n" + w.lvl1 + "\n\n" + w.lvl2 + "\n\n" + w.lvl3;
            if (!w.isUsed)
            {
                MWU.SetActive(true);
            }
            else
            {
                MWU.SetActive(false);
            }
            if (allWeapons[2].level != 3)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            GU1.SetActive(false); GU2.SetActive(false);
        }
        else if (w.i.sprite == allWeapons[3].Icon)
        {
            //magic scepter
            w.lvl1 = "Level 1:\nDeals 35 damage.";
            w.lvl2 = "Level 2:\nNow it heals you with 10 HP every turn.";
            w.lvl3 = "Level 3:\n+50% healed HP.";
            description.text = allWeapons[3].Name + "\nLevel: " + allWeapons[3].level + "\n\n" + w.lvl1 + "\n\n" + w.lvl2 + "\n\n" + w.lvl3;
            if (!w.isUsed)
            {
                MWU.SetActive(true);
            }
            else
            {
                MWU.SetActive(false);
            }
            if (allWeapons[3].level != 3)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            GU1.SetActive(false); GU2.SetActive(false);
        }
        else if (w.i.sprite == allWeapons[4].Icon)
        {
            //cave bombs
            w.lvl1 = "Level 1:\nDeals 15 damage and gives the enemy Double Damage every 3 enemy turns.";
            w.lvl2 = "Level 2:\n+33% damage.";
            w.lvl3 = "Level 3:\n+25% damage & Now it gives Double Damage every 2 enemy turns.";
            description.text = allWeapons[4].Name + "\nLevel: " + allWeapons[4].level + "\n\n" + w.lvl1 + "\n\n" + w.lvl2 + "\n\n" + w.lvl3;
            if (!w.isUsed)
            {
                MWU.SetActive(true);
            }
            else
            {
                MWU.SetActive(false);
            }
            if (allWeapons[4].level != 3)
            {
                UP.SetActive(true);
            }
            else
            {
                UP.SetActive(false);
            }
            GU1.SetActive(false); GU2.SetActive(false);
        }
        else if(w.i.sprite == emptyW)
        {
            UP.SetActive(false); GU1.SetActive(false); GU2.SetActive(false); MWU.SetActive(false); description.text = " ";
        }
    }

    public void MainWeaponUse()
    {
        if(ClickedWeapon != null && ClickedWeapon.i.sprite != emptyW)
        {
            au.PlayOneShot(click);
            DataCrosser.WeaponIndex = ClickedWeapon.ID;
            Sprite s = ClickedWeapon.i.sprite;
            ClickedWeapon.i.sprite = SelectedWeapon.i.sprite;
            SelectedWeapon.i.sprite = s;
            UP.SetActive(false); MWU.SetActive(false); description.text = "";
        }
        SaveManager.SaveGame();
    }
    public void Gadget1Use()
    {
        if (ClickedGadget != null && ClickedGadget.i.sprite != allGadgets[0].Icon)
        {
            au.PlayOneShot(click);
            for (int i = 2; i < 12; i++)
            {
                if(allGadgets[i].Icon == allGadgets[0].i.sprite)
                {
                    allGadgets[i].i.sprite = allGadgets[i].Icon;
                }
            }
            SelectedGadgets[0] = ClickedGadget;
            DataCrosser.Gadget1Index = SelectedGadgets[0].ID;
            //DataCrosser.Gadget1Level = SelectedGadgets[0].level;
            allGadgets[0].i.sprite = ClickedGadget.i.sprite;
            ClickedGadget.i.sprite = allGadgets[0].Icon;
            UP.SetActive(false); GU1.SetActive(false); GU2.SetActive(false); description.text = "";
        }
        SaveManager.SaveGame();
    }
    public void Gadget2Use()
    {
        if (ClickedGadget != null && ClickedGadget.i.sprite != allGadgets[0].Icon)
        {
            au.PlayOneShot(click);
            for (int i = 2; i < 12; i++)
            {
                if (allGadgets[i].Icon == allGadgets[1].i.sprite)
                {
                    allGadgets[i].i.sprite = allGadgets[i].Icon;
                }
            }
            SelectedGadgets[1] = ClickedGadget;
            DataCrosser.Gadget2Index = SelectedGadgets[1].ID;
            //DataCrosser.Gadget2Level = SelectedGadgets[1].level;
            allGadgets[1].i.sprite = ClickedGadget.i.sprite;
            ClickedGadget.i.sprite = allGadgets[0].Icon;
            UP.SetActive(false); GU1.SetActive(false); GU2.SetActive(false); description.text = "";
        }
        SaveManager.SaveGame();
    }
    public void Upgrade()
    {
        if (ClickedWeapon != null && ClickedWeapon.i.sprite != emptyW)
        {
            if(gems >= ClickedWeapon.upgradeCost)
            {
                au.PlayOneShot(up);
                if (ClickedWeapon.i.sprite == allWeapons[0].Icon) { UpgradeWeapon(allWeapons[0]); DataCrosser.Weapons[0]++; }
                else if (ClickedWeapon.i.sprite == allWeapons[1].Icon) { UpgradeWeapon(allWeapons[1]); DataCrosser.Weapons[1]++; }
                else if (ClickedWeapon.i.sprite == allWeapons[2].Icon) { UpgradeWeapon(allWeapons[2]); DataCrosser.Weapons[2]++; }
                else if (ClickedWeapon.i.sprite == allWeapons[3].Icon) { UpgradeWeapon(allWeapons[3]); DataCrosser.Weapons[3]++; }
                else if (ClickedWeapon.i.sprite == allWeapons[4].Icon) { UpgradeWeapon(allWeapons[4]); DataCrosser.Weapons[4]++; }
            }
        }
        else if(ClickedGadget != null && ClickedGadget.i.sprite != allGadgets[0].Icon)
        {
            if (gadgetTokens >= ClickedGadget.upgradeCost)
            {
                au.PlayOneShot(up);
                if (ClickedGadget.i.sprite == allGadgets[2].Icon) { UpgradeGadget(allGadgets[2]); DataCrosser.Gadgets[0]++; }
                else if (ClickedGadget.i.sprite == allGadgets[3].Icon) { UpgradeGadget(allGadgets[3]); DataCrosser.Gadgets[1]++; }
                else if (ClickedGadget.i.sprite == allGadgets[4].Icon) { UpgradeGadget(allGadgets[4]); DataCrosser.Gadgets[2]++; }
                else if (ClickedGadget.i.sprite == allGadgets[5].Icon) { UpgradeGadget(allGadgets[5]); DataCrosser.Gadgets[3]++; }
                else if (ClickedGadget.i.sprite == allGadgets[6].Icon) { UpgradeGadget(allGadgets[6]); DataCrosser.Gadgets[4]++; }
                else if (ClickedGadget.i.sprite == allGadgets[7].Icon) { UpgradeGadget(allGadgets[7]); DataCrosser.Gadgets[5]++; }
                else if (ClickedGadget.i.sprite == allGadgets[8].Icon) { UpgradeGadget(allGadgets[8]); DataCrosser.Gadgets[6]++; }
                else if (ClickedGadget.i.sprite == allGadgets[9].Icon) { UpgradeGadget(allGadgets[9]); DataCrosser.Gadgets[7]++; }
                else if (ClickedGadget.i.sprite == allGadgets[10].Icon) { UpgradeGadget(allGadgets[10]); DataCrosser.Gadgets[8]++; }
                else if (ClickedGadget.i.sprite == allGadgets[11].Icon) { UpgradeGadget(allGadgets[11]); DataCrosser.Gadgets[9]++; }
            }
        }
        SaveManager.SaveGame();
    }

    public void UnlockG()
    {
        for(int i = 0; i < 10; i++)
        {
            if(DataCrosser.Gadgets[i] > 0)
            {
                allGadgets[i + 2].i.sprite = allGadgets[i + 2].Icon;
                if(DataCrosser.Gadgets[i] == 2)
                {
                    allGadgets[i + 2].Upgrade();
                }
            }
        }
    }

    public void UnlockW()
    {
        for (int i = 0; i < 5; i++)
        {
            if (DataCrosser.Weapons[i] > 0)
            {
                allWeapons[i].i.sprite = allWeapons[i].Icon;
                if (DataCrosser.Weapons[i] == 2)
                {
                    allWeapons[i].Upgrade();
                    if (DataCrosser.Weapons[i] == 3) allWeapons[i].Upgrade();
                }
            }
        }
    }
    IEnumerator s()
    {
        yield return new WaitForSeconds(0.2f);
        
        UnlockG(); UnlockW();
        if(DataCrosser.Gadget1Index != 0)
        {
            allGadgets[0].i.sprite = allGadgets[DataCrosser.Gadget1Index].Icon;
            allGadgets[DataCrosser.Gadget1Index].i.sprite = allGadgets[0].Icon;
        }
        if (DataCrosser.Gadget2Index != 0)
        {
            allGadgets[1].i.sprite = allGadgets[DataCrosser.Gadget2Index].Icon;
            allGadgets[DataCrosser.Gadget2Index].i.sprite = allGadgets[1].Icon;
        }
    }
}
