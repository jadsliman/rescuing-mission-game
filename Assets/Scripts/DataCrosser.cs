using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataCrosser
{
    public static int EnemyNumber;
    public static int Levelindex;
    public static float music = 1f, sfx = 1f;
    public static bool isReturningFromBattle = false, Star = false, Gadget = false, GT = false, IsFinal = false, IsClockwise = false, LostBattle = false, WonThisLevelBefore = false, EnvCompleted = false, FTGM = true, FTF = false, FF = true, RC = false;
    public static Vector3 WizardReturningPos, CloneReturningPos;
    public static Vector3Int current, cloneCurrent;
    public static int moves, enemies, EnvIndex, Lava, SelectedEnv, WonLevels = 0, VideoNumber;
    public static int[] Gadgets = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] Weapons = { 0, 0, 0, 0, 0 };
    public static int GTs = 0, Gems = 0, GemsPerLevel;
    public static bool[] GotKeys = new bool[8];
    public static bool[] doorOpened = new bool[8];
    public static bool[] FallenBlocks = new bool[10];
    public static bool Enemy1 = false, Enemy2 = false, Enemy3 = false, Enemy4 = false, Enemy5 = false, Enemy6 = false;

    public static int Gadget1Index = 0;
    public static int Gadget2Index = 0;
    public static int WeaponIndex = 0;
}
