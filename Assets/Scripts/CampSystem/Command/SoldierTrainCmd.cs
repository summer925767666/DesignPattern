using System;
using UnityEngine;

public class SoldierTrainCmd : Command
{
    private Type soldierType;
    private Type weaponType;
    private Vector3 spawnPos;
    private int lv;

    public SoldierTrainCmd(Type soldierType, Type weaponType, Vector3 spawnPos, int lv)
    {
        this.soldierType = soldierType;
        this.weaponType = weaponType;
        this.spawnPos = spawnPos;
        this.lv = lv;
    }


    public override void Execute()
    {
        FactoryManger.SoldierFactory.CreatCharacter(soldierType, weaponType, spawnPos, lv);
    }
}