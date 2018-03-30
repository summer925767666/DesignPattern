using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AchievementMemento
{
    public int EnemyKilledCount { get; set; }

    public int SoldierKilledCount { get; set; }

    public int MaxStageLv { get; set; }


    public void LoadData()
    {
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        MaxStageLv = PlayerPrefs.GetInt("MaxStageLv",1);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLv", MaxStageLv);
    }
}

