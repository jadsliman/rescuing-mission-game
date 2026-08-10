using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string FighterName;
    public int HP, CurrentHP, ShieldPoints;
    public bool isPlayer;
    public int damage;
    public Animator a;
    public Block block;

    private void Awake()
    {
        for(int i = 0; i < (DataCrosser.WonLevels - 3) / 15; i++)
        {
            HP += (25 * HP) / 100;
        }
        CurrentHP = HP;
        a = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (ShieldPoints >= damage) ShieldPoints -= damage;
        else if(ShieldPoints < damage && ShieldPoints > 0)
        {
            damage -= ShieldPoints;
            ShieldPoints = 0;
            CurrentHP -= damage;
            CurrentHP = Mathf.Max(0, CurrentHP);
        }
        else
        {
            CurrentHP -= damage;
            CurrentHP = Mathf.Max(0, CurrentHP);
        }
    }

    public bool IsDead()
    {
        return CurrentHP <= 0;
    }

    public void Heal(int heal)
    {
        CurrentHP += heal;
        CurrentHP = Mathf.Min(CurrentHP, HP);
    }
}
