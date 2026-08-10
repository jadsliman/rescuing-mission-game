using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{
    public static Grid_Manager Instance;
    public int Width, Height;
    public int LevelIndex;

    private void Start()
    {
        DataCrosser.Levelindex = LevelIndex;
        if (LevelIndex >= 0 && LevelIndex <= 2) DataCrosser.EnvIndex = 0;
        else if ((LevelIndex >= 3 && LevelIndex <= 17) || LevelIndex == 83 || LevelIndex == 86 || LevelIndex == 88) DataCrosser.EnvIndex = 1;
        else if ((LevelIndex >= 18 && LevelIndex <= 32) || LevelIndex == 78 || LevelIndex == 85 || LevelIndex == 90) DataCrosser.EnvIndex = 2;
        else if ((LevelIndex >= 33 && LevelIndex <= 47) || LevelIndex == 81 || LevelIndex == 92) DataCrosser.EnvIndex = 3;
        else if ((LevelIndex >= 48 && LevelIndex <= 62) || LevelIndex == 84 || LevelIndex == 87 || LevelIndex == 91) DataCrosser.EnvIndex = 4;
        else if ((LevelIndex >= 63 && LevelIndex <= 77) || LevelIndex == 79 || LevelIndex == 80 || LevelIndex == 82 || LevelIndex == 89) DataCrosser.EnvIndex = 5;
        if (LevelIndex < 92 && LevelIndex > 87) DataCrosser.IsFinal = true;
    }

    private void Awake()
    {
        Instance = this;
    }
}
