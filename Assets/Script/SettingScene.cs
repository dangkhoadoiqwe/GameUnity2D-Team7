using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScene : MonoBehaviour
{
    public GameLevelData levelData;

    public void ClearGameData()
    {
        DataSaver.ClearGameData(levelData);
    }
}
