using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Fight_Manager : MonoBehaviour
{
    public Fighter Player;
    public Fighter[] Monsters; public int n;
    Fighter Enemy;
    public Shot Eshot, Pshot, ChTshot, FBshot; public Shot[] Pshots, Eshots;
    public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
    private BattleState state;
    bool mw, g, firstTurn;
    public TextMeshProUGUI PHP, EHP, PSP, ESP;
    public Image PHPBar, EHPBar, MW, G1, G2, Red, Green, Grey, ERed, EGreen, EGrey, banned, weapon, gadget1, gadget2;
    public Image[] HPBars = new Image[11], Blocks = new Image[6], EBlocks = new Image[6], BGs = new Image[6], Weapons = new Image[5], Gadgets = new Image[10];
    int i, j, ExtraDamage;
    bool isPoison = false, isAxe = false, isSepter = false, DD = false, TD = false, IsBomb = false,
        RevengePower = false, Cancel = false, CP1 = false, CP2 = false;
    public GameObject In, Out, ET, PT;
    public AudioSource au; public AudioClip sword, scepter, explosion, heal, cancel, win, lose, Song, Lazer, Attack;
    
    void Start()
    {
        Out.SetActive(true);
        au.volume = DataCrosser.sfx;
        foreach (Fighter f in Monsters)
        {
            f.gameObject.SetActive(false);
        }
        foreach (Shot s in Pshots)
        {
            s.gameObject.SetActive(false);
        }
        foreach (Shot s in Eshots)
        {
            s.gameObject.SetActive(false);
        }
        n = DataCrosser.EnemyNumber;
        Monsters[n].gameObject.SetActive(true);
        Enemy = Monsters[n];
        Pshots[DataCrosser.WeaponIndex].gameObject.SetActive(true);
        Pshot = Pshots[DataCrosser.WeaponIndex];
        
        PHPBar.sprite = HPBars[0].sprite; EHPBar.sprite = HPBars[0].sprite;
        mw = false; g = true;
        StartCoroutine(StartBattle());
        i = 0; ExtraDamage = 0;
        Blocks[DataCrosser.EnvIndex].gameObject.SetActive(true);
        EBlocks[DataCrosser.EnvIndex].gameObject.SetActive(true);
        BGs[DataCrosser.EnvIndex].gameObject.SetActive(true);
        PSP.text = Player.ShieldPoints.ToString() + " SP";
        PHP.text = Player.CurrentHP.ToString() + " HP";
        EHP.text = Enemy.CurrentHP.ToString() + " HP";
        ESP.text = Enemy.ShieldPoints.ToString() + " SP";
        if (DataCrosser.EnvIndex == 2) Enemy.a.SetBool("Lava", true);
        else if (DataCrosser.EnvIndex == 3) Enemy.a.SetBool("Magic", true);
        else if (DataCrosser.EnvIndex == 4) Enemy.a.SetBool("Cave", true);
        else if (DataCrosser.EnvIndex == 5) Enemy.a.SetBool("Ice", true);
        if (DataCrosser.Gadget1Index > 1) gadget1.sprite = Gadgets[DataCrosser.Gadget1Index - 2].sprite;
        if (DataCrosser.Gadget2Index > 1) gadget2.sprite = Gadgets[DataCrosser.Gadget2Index - 2].sprite;
        weapon.sprite = Weapons[DataCrosser.WeaponIndex].sprite;
        firstTurn = true;
        if (DataCrosser.EnemyNumber == 5 && !DataCrosser.IsFinal)
        {
            Eshots[DataCrosser.EnvIndex - 1].gameObject.SetActive(true);
            Eshot = Eshots[DataCrosser.EnvIndex - 1];
        }
        else if (DataCrosser.EnemyNumber == 5 && DataCrosser.IsFinal)
        {
            Eshots[DataCrosser.EnvIndex + 5].gameObject.SetActive(true);
            Eshot = Eshots[DataCrosser.EnvIndex + 5];
        }
        else if (Enemy.name == "Robot")
        {
            Eshots[5].gameObject.SetActive(true);
            Eshot = Eshots[5];
        }
    }

    void Update()
    {

    }

    public void ClickMWB()
    {
        if(!mw)
        {
            int d, m;
            //Weapons
            if(DataCrosser.WeaponIndex == 0)
            {
                //Natural Sword
                m = 0; isPoison = true; au.PlayOneShot(sword);
                if (DataCrosser.Weapons[0] == 1) { d = 25; if(i == 0 || i == 3) EGreen.gameObject.SetActive(true); }
                else if(DataCrosser.Weapons[0] == 2) { d = 30; if (i == 0 || i == 3) EGreen.gameObject.SetActive(true); }
                else { d = 30; if (i == 0 || i == 2) EGreen.gameObject.SetActive(true); }
            }
            else if(DataCrosser.WeaponIndex == 1)
            {
                //Flaming Sickle
                m = 1; au.PlayOneShot(sword);
                if (DataCrosser.Weapons[1] == 1) { d = 30; }
                else if(DataCrosser.Weapons[1] == 2) { d = 40; }
                else { d = 45; }
            }
            else if (DataCrosser.WeaponIndex == 2)
            {
                //Ice Axe
                m = 2; isAxe = true; EGrey.gameObject.SetActive(true); au.PlayOneShot(sword);
                if (DataCrosser.Weapons[2] == 1) { d = 25; }
                else { d = 30; }
            }
            else if (DataCrosser.WeaponIndex == 3)
            {
                //Magic Scepter
                m = 3; au.PlayOneShot(scepter);
                if (DataCrosser.Weapons[3] == 1) { d = 35; }
                else if (DataCrosser.Weapons[3] == 2) { d = 35; isSepter = true; }
                else { d = 45; isSepter = true; }
            }
            else
            {
                m = 4; IsBomb = true;
                if (DataCrosser.Weapons[4] == 1) { d = 15; }
                else if (DataCrosser.Weapons[4] == 2) { d = 20; }
                else { d = 25; }
            }
            mw = true; MainWeapon(d, m);
        }
    }

    public void ClickFGB()
    {
        if (!g)
        {
            int m;
            //Gadgets nums
            if(DataCrosser.Gadget1Index == 2) { m = 0; g = true; }
            else if (DataCrosser.Gadget1Index == 3) { m = 1; g = true; }
            else if (DataCrosser.Gadget1Index == 4) { m = 2; g = true; }
            else if (DataCrosser.Gadget1Index == 5) { m = 3; g = true; }
            else if (DataCrosser.Gadget1Index == 6) { m = 4; g = true; }
            else if (DataCrosser.Gadget1Index == 7) { m = 5; g = true; }
            else if (DataCrosser.Gadget1Index == 8) { m = 6; g = true; }
            else if (DataCrosser.Gadget1Index == 9) { m = 7; g = true; }
            else if (DataCrosser.Gadget1Index == 10) { m = 8; g = true; }
            else if (DataCrosser.Gadget1Index == 11) { m = 9; g = true; }
            else { m = 10; g = false; }
            Gadget(m);
        }
    }

    public void ClickSGB()
    {
        if (!g)
        {
            int m;
            //Gadgets nums
            if (DataCrosser.Gadget2Index == 2) { m = 0; g = true; }
            else if (DataCrosser.Gadget2Index == 3) { m = 1; g = true; }
            else if (DataCrosser.Gadget2Index == 4) { m = 2; g = true; }
            else if (DataCrosser.Gadget2Index == 5) { m = 3; g = true; }
            else if (DataCrosser.Gadget2Index == 6) { m = 4; g = true; }
            else if (DataCrosser.Gadget2Index == 7) { m = 5; g = true; }
            else if (DataCrosser.Gadget2Index == 8) { m = 6; g = true; }
            else if (DataCrosser.Gadget2Index == 9) { m = 7; g = true; }
            else if (DataCrosser.Gadget2Index == 10) { m = 8; g = true; }
            else if (DataCrosser.Gadget2Index == 11) { m = 9; g = true; }
            else { m = 10; g = false; }
            Gadget(m);
        }
    }

    IEnumerator StartBattle()
    {
        state = BattleState.Start;
        //animate start animation
        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
        PT.SetActive(true);
        PlayerTurn();
    }

    IEnumerator EnemyTurn()
    {
        if(!Cancel)
        {
            yield return new WaitForSeconds(2f);
            ET.SetActive(true);
            PT.SetActive(false);
            state = BattleState.EnemyTurn;
            if (isPoison && DataCrosser.Weapons[0] == 1) Poison(10, 3);
            else if (isPoison && DataCrosser.Weapons[0] == 2) Poison(15, 3);
            else if (isPoison && DataCrosser.Weapons[0] == 3) Poison(15, 2);
            if (IsBomb && (DataCrosser.Weapons[4] == 1 || DataCrosser.Weapons[4] == 2)) DoubleDamage(3);
            else if (IsBomb && DataCrosser.Weapons[4] == 3) DoubleDamage(2);
            yield return new WaitForSeconds(0.3f);
            if(!Enemy.IsDead())
            {
                if (DataCrosser.EnemyNumber == 5 && (DataCrosser.EnvIndex == 1 || DataCrosser.EnvIndex == 2 || DataCrosser.EnvIndex == 5))
                { au.PlayOneShot(sword); }
                else if (DataCrosser.EnemyNumber == 5 && (DataCrosser.EnvIndex == 3))
                { au.PlayOneShot(scepter); }
                if (DataCrosser.IsFinal) Enemy.a.SetTrigger("Attack 2");
                else Enemy.a.SetTrigger("Attack");
                if (DataCrosser.EnemyNumber == 0 || DataCrosser.EnemyNumber == 2) au.PlayOneShot(Attack);
                else if (DataCrosser.EnemyNumber == 1) au.PlayOneShot(Lazer);
                yield return new WaitForSeconds(0.3f);
                if (DataCrosser.EnemyNumber == 3) au.PlayOneShot(Lazer);
                if (isAxe && (DataCrosser.Weapons[2] == 1 || DataCrosser.Weapons[2] == 2))
                {
                    if (CP1)
                    {
                        Player.TakeDamage(((Enemy.damage - (Enemy.damage / 4)) * 90) / 100); CP1 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else if (CP2)
                    {
                        Player.TakeDamage(((Enemy.damage - (Enemy.damage / 4)) * 85) / 100); CP2 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else
                    {
                        Player.TakeDamage(Enemy.damage - (Enemy.damage / 4));
                        EGrey.gameObject.SetActive(false);
                    }
                }
                else if (isAxe && DataCrosser.Weapons[2] == 3)
                {
                    if (CP1)
                    {
                        Player.TakeDamage((((Enemy.damage * 70) / 100) * 90) / 100); CP1 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else if (CP2)
                    {
                        Player.TakeDamage((((Enemy.damage * 70) / 100) * 85) / 100); CP2 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else
                    {
                        Player.TakeDamage((Enemy.damage * 70) / 100);
                        EGrey.gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (CP1)
                    {
                        Player.TakeDamage((Enemy.damage * 75) / 100); CP1 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else if (CP2)
                    {
                        Player.TakeDamage((Enemy.damage * 60) / 100); CP2 = false;
                        EGrey.gameObject.SetActive(false);
                    }
                    else
                    {
                        Player.TakeDamage(Enemy.damage);
                    }
                }
                if (RevengePower)
                {
                    if (DataCrosser.Gadgets[3] == 1)
                    {
                        if (DD && !TD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 5) * 2); DD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else if (TD && !DD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 5) * 3); TD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else if (TD && DD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 5) * 6); DD = false; TD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else Enemy.TakeDamage(Enemy.damage / 5);
                    }
                    else
                    {
                        if (DD && !TD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 3) * 2); DD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else if (TD && !DD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 3) * 3); TD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else if (TD && DD)
                        {
                            Enemy.TakeDamage((Enemy.damage / 3) * 6); DD = false; TD = false;
                            ERed.gameObject.SetActive(false);
                        }
                        else Enemy.TakeDamage(Enemy.damage / 3);
                    }
                    Enemy.a.SetTrigger("Damaged");
                    if (Enemy.IsDead())
                    {
                        state = BattleState.Won;
                        EHPBar.sprite = HPBars[10].sprite;
                        EHP.text = "0 HP";
                        EndBattle(true);
                    }
                }
                yield return new WaitForSeconds(0.2f);
                if (Enemy.name == "Robot")
                {
                    yield return new WaitForSeconds(0.2f);
                    au.PlayOneShot(Lazer);
                    yield return new WaitForSeconds(0.2f);
                    Eshot.animator.SetTrigger("Shot");
                }
                else if (DataCrosser.EnemyNumber == 5)
                {
                    Eshot.animator.SetTrigger("Shot");
                    yield return new WaitForSeconds(0.2f);
                    if (DataCrosser.EnvIndex == 4) au.PlayOneShot(explosion);
                }

                Player.a.SetTrigger("Damaged");
                ChangeHPBar();
                if (Player.IsDead())
                {
                    state = BattleState.Lost;
                    PHPBar.sprite = HPBars[10].sprite;
                    PHP.text = "0 HP";
                    EndBattle(false);
                }
                else
                {
                    yield return new WaitForSeconds(1.7f);
                    state = BattleState.PlayerTurn;
                    PlayerTurn();
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(1.7f);
            banned.gameObject.SetActive(false);
            state = BattleState.PlayerTurn;
            PlayerTurn();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Pshot.animator.SetTrigger("Shot");
        yield return new WaitForSeconds(0.2f);
        if (DataCrosser.WeaponIndex == 4) au.PlayOneShot(explosion);
        Enemy.a.SetTrigger("Damaged");
        ChangeHPBar();
    }

    IEnumerator FB()
    {
        yield return new WaitForSeconds(0.6f);
        FBshot.animator.SetTrigger("Shot");
        yield return new WaitForSeconds(0.3f);
        au.PlayOneShot(explosion);
        Enemy.a.SetTrigger("Damaged");
        if (DataCrosser.Gadgets[2] == 1)
        {
            if (DD && !TD)
            {
                Enemy.TakeDamage(20); DD = false; ERed.gameObject.SetActive(false);
            }
            else if (TD && !DD)
            {
                Enemy.TakeDamage(30); TD = false;
                ERed.gameObject.SetActive(false);
            }
            else if (TD && DD)
            {
                Enemy.TakeDamage(60); DD = false; TD = false;
                ERed.gameObject.SetActive(false);
            }
            else Enemy.TakeDamage(10);
            if (Enemy.IsDead())
            {
                state = BattleState.Won;
                EHPBar.sprite = HPBars[10].sprite;
                EHP.text = "0 HP";
                EndBattle(true);
            }
        }
        else
        {
            if (DD)
            {
                Enemy.TakeDamage(30); DD = false;
                ERed.gameObject.SetActive(false);
            }
            else if (TD && !DD)
            {
                Enemy.TakeDamage(45); TD = false;
                ERed.gameObject.SetActive(false);
            }
            else if (TD && DD)
            {
                Enemy.TakeDamage(90); DD = false; TD = false;
                ERed.gameObject.SetActive(false);
            }
            else Enemy.TakeDamage(15);
        }
        ChangeHPBar();
    }

    void PlayerTurn()
    {
        ET.SetActive(false);
        PT.SetActive(true);
        if (firstTurn) { mw = false; g = true; firstTurn = false; }
        else { mw = false; g = false; }
    }

    void MainWeapon(int damage, int m)
    {
        if (state != BattleState.PlayerTurn) return;
        //Animations
        if (m == 0) { Player.a.SetTrigger("Attack 1"); }
        else if (m == 1) { Player.a.SetTrigger("Attack 2"); }
        else if (m == 2) { Player.a.SetTrigger("Attack 5"); }
        else if (m == 3) { Player.a.SetTrigger("Attack 3"); }
        else if (m == 4) { Player.a.SetTrigger("Attack 4"); }
        if (DD && !TD)
        {
            Enemy.TakeDamage((damage + ExtraDamage) * 2); DD = false; ERed.gameObject.SetActive(false);
        }
        else if(TD && !DD)
        {
            Enemy.TakeDamage((damage + ExtraDamage) * 3); TD = false; ERed.gameObject.SetActive(false);
        }
        else if(TD && DD)
        {
            Enemy.TakeDamage((damage + ExtraDamage) * 6); DD = false; TD = false; ERed.gameObject.SetActive(false);
        }
        else Enemy.TakeDamage((damage + ExtraDamage));
        ExtraDamage = 0;
        if (isSepter && DataCrosser.Weapons[3] == 2) Player.Heal(10);
        else if (isSepter && DataCrosser.Weapons[3] == 3) Player.Heal(15);
        StartCoroutine(Wait());
        if (mw)
        {
            if (Enemy.IsDead())
            {
                state = BattleState.Won;
                EHPBar.sprite = HPBars[10].sprite;
                EHP.text = "0 HP";
                EndBattle(true);
            }
            else if(g)
                StartCoroutine(EnemyTurn());
        }
    }

    void Gadget(int n)
    {
        if (state != BattleState.PlayerTurn) return;
        //effect & Animations - don't forget the DD & the effects icons
        if(n == 0)
        {
            //First aid kit
            Player.a.SetTrigger("First Aid Kit");
            au.PlayOneShot(heal);
            if (DataCrosser.Gadgets[0] == 1) Player.Heal(15);
            else Player.Heal(30);
            ChangeHPBar();
        }
        else if(n == 1)
        {
            //Iron shield
            Player.a.SetTrigger("Iron Shield");
            au.PlayOneShot(heal);
            if (DataCrosser.Gadgets[1] == 1) Player.ShieldPoints += 12;
            else Player.ShieldPoints += 20;
            ChangeHPBar();
        }
        else if(n == 2)
        {
            //Fire ball
            Player.a.SetTrigger("Fire Ball");
            StartCoroutine(FB());
        }
        else if (n == 3)
        {
            //Revenge power
            Player.a.SetTrigger("Revenge Power");
            au.PlayOneShot(cancel);
            RevengePower = true;
        }
        else if (n == 4)
        {
            //True punishment
            Player.a.SetTrigger("True Punishment");
            au.PlayOneShot(cancel);
            if (DataCrosser.Gadgets[4] == 1) DD = true;
            else TD = true;
            ERed.gameObject.SetActive(true);
        }
        else if (n == 5)
        {
            //Cheating try
            Player.a.SetTrigger("Cheating Try");
            ChTshot.animator.SetTrigger("Shot");
            au.PlayOneShot(cancel);
            System.Random random = new System.Random();
            int randomNumber = random.Next(100);
            if (DataCrosser.Gadgets[5] == 1)
            {
                if (randomNumber < 5) { Cancel = true; banned.gameObject.SetActive(true); }
                else Cancel = false;
            }
            else
            {
                if (randomNumber < 10) { Cancel = true; banned.gameObject.SetActive(true); }
                else Cancel = false;
            }
        }
        else if (n == 6)
        {
            //Mega gift
            Player.a.SetTrigger("Mega Gift");
            au.PlayOneShot(heal);
            if (DataCrosser.Gadgets[6] == 1)
            {
                Player.Heal(10); Player.ShieldPoints += 10; ExtraDamage = 10;
                ChangeHPBar();
            }
            else
            {
                Player.Heal(15); Player.ShieldPoints += 15; ExtraDamage = 15;
                ChangeHPBar();
            }
        }
        else if (n == 7)
        {
            //Guaranteed safety
            Player.a.SetTrigger("Guaranteed Safety");
            au.PlayOneShot(heal);
            if (DataCrosser.Gadgets[7] == 1)
            {
                Player.CurrentHP -= 30;
                Player.CurrentHP = Mathf.Max(0, Player.CurrentHP);
                Player.ShieldPoints += Enemy.damage;
                ChangeHPBar();
                if (Player.IsDead())
                {
                    state = BattleState.Lost;
                    PHPBar.sprite = HPBars[10].sprite;
                    PHP.text = "0 HP";
                    EndBattle(false);
                }
            }
            else
            {
                Player.CurrentHP -= 20;
                Player.CurrentHP = Mathf.Max(0, Player.CurrentHP);
                Player.ShieldPoints += Enemy.damage;
                ChangeHPBar();
                if (Player.IsDead())
                {
                    state = BattleState.Lost;
                    PHPBar.sprite = HPBars[10].sprite;
                    PHP.text = "0 HP";
                    EndBattle(false);
                }
            }
        }
        else if (n == 8)
        {
            //Stealing life
            Player.a.SetTrigger("Stealing Life");
            au.PlayOneShot(heal);
            int h = (Player.CurrentHP * Enemy.HP) / Player.HP;
            Player.CurrentHP = (Enemy.CurrentHP * Player.HP) / Enemy.HP;
            Enemy.CurrentHP = h;
            if (DataCrosser.Gadgets[8] == 1)
            {
                Player.Heal(10);
            }
            ChangeHPBar();
        }
        else if (n == 9)
        {
            //Chicken power
            Player.a.SetTrigger("Chicken Power");
            au.PlayOneShot(heal);
            if (DataCrosser.Gadgets[9] == 1) { CP1 = true; EGrey.gameObject.SetActive(true); }
            else { CP2 = true; EGrey.gameObject.SetActive(true); }
        }
        else
        {
            //Empty
        }

        ChangeHPBar();

        if (g)
        {
            if (Enemy.IsDead())
            {
                state = BattleState.Won;
                EHPBar.sprite = HPBars[10].sprite;
                EHP.text = "0 HP";
                EndBattle(true);
            }
            else if(mw)
                StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle(bool won)
    {
        StartCoroutine(End(won));
    }

    void ChangeHPBar()
    {
        EHP.text = Enemy.CurrentHP.ToString() + " HP";
        ESP.text = Enemy.ShieldPoints.ToString() + " SP";
        PHP.text = Player.CurrentHP.ToString() + " HP";
        PSP.text = Player.ShieldPoints.ToString() + " SP";
        if (Player.CurrentHP > 0)
        {
            //Add Shield bar
            switch (((Player.CurrentHP * 100) / Player.HP) / 10)
            {
                case 10:
                    PHPBar.sprite = HPBars[0].sprite; break;
                case 9:
                    PHPBar.sprite = HPBars[1].sprite; break;
                case 8:
                    PHPBar.sprite = HPBars[2].sprite; break;
                case 7:
                    PHPBar.sprite = HPBars[3].sprite; break;
                case 6:
                    PHPBar.sprite = HPBars[4].sprite; break;
                case 5:
                    PHPBar.sprite = HPBars[5].sprite; break;
                case 4:
                    PHPBar.sprite = HPBars[6].sprite; break;
                case 3:
                    PHPBar.sprite = HPBars[7].sprite; break;
                case 2:
                    PHPBar.sprite = HPBars[8].sprite; break;
                case 1:
                case 0:
                    PHPBar.sprite = HPBars[9].sprite; break;
            }
        }
        if(Enemy.CurrentHP > 0)
        {
            switch (((Enemy.CurrentHP * 100) / Enemy.HP) / 10)
            {
                case 10:
                    EHPBar.sprite = HPBars[0].sprite; break;
                case 9:
                    EHPBar.sprite = HPBars[1].sprite; break;
                case 8:
                    EHPBar.sprite = HPBars[2].sprite; break;
                case 7:
                    EHPBar.sprite = HPBars[3].sprite; break;
                case 6:
                    EHPBar.sprite = HPBars[4].sprite; break;
                case 5:
                    EHPBar.sprite = HPBars[5].sprite; break;
                case 4:
                    EHPBar.sprite = HPBars[6].sprite; break;
                case 3:
                    EHPBar.sprite = HPBars[7].sprite; break;
                case 2:
                    EHPBar.sprite = HPBars[8].sprite; break;
                case 1:
                case 0:
                    EHPBar.sprite = HPBars[9].sprite; break;
            }
        }
    }
    void Poison(int d, int n)
    {
        if(state == BattleState.EnemyTurn)
        {
            if (i == n) i = 0;
            if(i == 0)
            {
                Enemy.TakeDamage(d);
                Enemy.a.SetTrigger("Damaged");
                ChangeHPBar();
                EGreen.gameObject.SetActive(false);
                if (Enemy.IsDead())
                {
                    state = BattleState.Won;
                    EHPBar.sprite = HPBars[10].sprite;
                    EHP.text = "0 HP";
                    EndBattle(true);
                }
            }
            i++;
        }
    }
    void DoubleDamage(int n)
    {
        if (state == BattleState.EnemyTurn)
        {
            if (i == n) i = 0;
            if (i == 0)
            {
                DD = true;
                ERed.gameObject.SetActive(true);
            }
            else DD = false;
            i++;
        }
    }

    private IEnumerator End(bool b)
    {
        if(b)
        {
            yield return new WaitForSeconds(0.7f);
            au.PlayOneShot(win);
            Enemy.a.SetBool("Lost", true);
            Player.a.SetBool("Won", true);
            DataCrosser.LostBattle = false;
        }
        else
        {
            yield return new WaitForSeconds(0.7f);
            au.PlayOneShot(lose);
            Player.a.SetBool("Lost", true);
            Enemy.a.SetBool("Won", true);
            DataCrosser.LostBattle = true;
        }
        yield return new WaitForSeconds(2.5f);
        In.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        MusicPlayer.instance.ChangeMusic(Song);
        SceneManager.LoadScene(DataCrosser.Levelindex + 1);
    }
}
