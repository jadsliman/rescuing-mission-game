using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void SaveGame()
    {
        SavaData data = new SavaData();
        data.WonLevels = DataCrosser.WonLevels;
        data.Gems = DataCrosser.Gems;
        data.GTs = DataCrosser.GTs;
        data.IsClockWise = DataCrosser.IsClockwise;
        data.WI = DataCrosser.WeaponIndex;
        data.G1I = DataCrosser.Gadget1Index;
        data.G2I = DataCrosser.Gadget2Index;
        data.Weapons = DataCrosser.Weapons;
        data.Gadgets = DataCrosser.Gadgets;
        data.ff = DataCrosser.FF;
        data.ftf = DataCrosser.FTF;
        data.ftgm = DataCrosser.FTGM;
        data.rc = DataCrosser.RC;
        data.music = DataCrosser.music;
        data.sfx = DataCrosser.sfx;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public static void LoadGame()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SavaData data = JsonUtility.FromJson<SavaData>(json);
            DataCrosser.WonLevels = data.WonLevels;
            DataCrosser.Gems = data.Gems;
            DataCrosser.GTs = data.GTs;
            DataCrosser.IsClockwise = data.IsClockWise;
            DataCrosser.Weapons = data.Weapons;
            DataCrosser.Gadgets = data.Gadgets;
            DataCrosser.Gadget1Index = data.G1I;
            DataCrosser.Gadget2Index = data.G2I;
            DataCrosser.WeaponIndex = data.WI;
            DataCrosser.FF = data.ff;
            DataCrosser.FTF = data.ftf;
            DataCrosser.FTGM = data.ftgm;
            DataCrosser.RC = data.rc;
            DataCrosser.music = data.music;
            DataCrosser.sfx = data.sfx;
        }
    }
}
