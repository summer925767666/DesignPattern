using System;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private readonly Dictionary<Type, BaseCamp> captiveCamps = new Dictionary<Type, BaseCamp>();
    private readonly Dictionary<Type, BaseCamp> soldierCamps = new Dictionary<Type, BaseCamp>();


    public void Init()
    {
        IniSoldierCamp(typeof(SoldierRookie), "新手兵营", "RookieCamp", 3);
        IniSoldierCamp(typeof(SoldierSergeant), "中士兵营", "SergeantCamp", 4);
        IniSoldierCamp(typeof(SoldierCaptain), "上尉兵营", "CaptainCamp", 5);
        IniCaptiveCamp(typeof(EnemyElf), "CaptiveCamp", 3);
    }

    public void Update()
    {
        foreach (var camp in soldierCamps.Values) camp.Update();
        foreach (var captiveCamp in captiveCamps.Values) { captiveCamp.Update(); }
    }

    public void Release() { }

    private void IniSoldierCamp(Type soldierType, string name, string iconName, float trainTime)
    {
        var go = GameObject.Find("Camps").transform.Find(soldierType.ToString()).gameObject;
        var spawnPos = go.transform.Find("Camp/TrainPoint").position;
        BaseCamp camp = new SoldierCamp(name, iconName, soldierType, spawnPos, trainTime);

        go.AddComponent<CampOnClick>().Camp = camp; //添加点击事件监测脚本

        soldierCamps.Add(soldierType, camp);
    }

    private void IniCaptiveCamp(Type enemyType, string iconName, float trainTime)
    {
        var go = GameObject.Find("Camps").transform.Find(enemyType.ToString()).gameObject;
        var spawnPos = go.transform.Find("Camp/TrainPoint").position;
        BaseCamp camp = new CaptiveCamp(iconName, enemyType, spawnPos, trainTime);

        go.AddComponent<CampOnClick>().Camp = camp; //添加点击事件监测脚本

        captiveCamps.Add(enemyType, camp);
    }
}