using System;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<Type, BaseCamp> camps = new Dictionary<Type, BaseCamp>();

    public void Init()
    {
        IniCamp(typeof(SoldierRookie), "新手兵营", "RookieCamp", 3);
        IniCamp(typeof(SoldierSergeant), "中士兵营", "SergeantCamp", 4);
        IniCamp(typeof(SoldierCaptain), "上尉兵营", "CaptainCamp", 5);
    }

    public void Update()
    {
        foreach (var camp in camps.Values)
        {
            camp.Update();
        }
    }

    public void Release()
    {
    }

    private void IniCamp(Type soldierType, string name, string iconName, float trainTime)
    {
        GameObject go = GameObject.Find("Camps").transform.Find(soldierType.ToString()).gameObject;
        Vector3 pos = go.transform.Find("Camp/TrainPoint").position;
        BaseCamp camp = new SoldierCamp(go, name, iconName, soldierType, pos, trainTime);

        go.AddComponent<CampOnClick>().Camp = camp; //添加点击事件监测脚本

        camps.Add(soldierType, camp);
    }
}