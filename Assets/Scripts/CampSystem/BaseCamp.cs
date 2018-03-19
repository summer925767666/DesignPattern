using System;
using UnityEngine;

public abstract class BaseCamp
{
    protected GameObject GameObject;
    protected string _Name;
    protected string _IconName;
    protected Type SoldierType;
    protected Vector3 SpawnPos;
    protected float TrainTime;

    public string Name { get { return _Name; } }
    public string IconName { get { return _IconName; } }
    public abstract int Lv { get; }
    public abstract int WeaponLv { get; }


    public BaseCamp(GameObject gameObject, string name, string iconName, Type soldierType, Vector3 spawnPos,float trainTime)
    {
        GameObject = gameObject;
        _Name = name;
        _IconName = iconName;
        SoldierType = soldierType;
        SpawnPos = spawnPos;
        TrainTime = trainTime;
    }

    public virtual void Update()
    {
        
    }
}

