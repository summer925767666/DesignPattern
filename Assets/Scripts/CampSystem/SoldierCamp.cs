using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SoldierCamp:BaseCamp
{
    private const int MaxLV = 4;
    private int lv = 1;
    private int weaponLv = 1;

    public override int Lv
    {
        get { return lv; }
    }

    public override int WeaponLv
    {
        get { return weaponLv; }
    }

    public SoldierCamp(GameObject gameObject, string name, string iconName, Type soldierType, Vector3 spawnPos, float trainTime, int lv = 1, int weaponLv = 1)
        : base(gameObject, name, iconName, soldierType, spawnPos, trainTime)
    {
        this.lv = lv;
        this.weaponLv = weaponLv;
    }

    
}

