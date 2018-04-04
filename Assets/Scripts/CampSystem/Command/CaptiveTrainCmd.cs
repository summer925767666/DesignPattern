using System;
using UnityEngine;
using System.Collections;

public class CaptiveTrainCmd :Command
{
    private Type enemyType;
    private Type weaponType;
    private Vector3 spawnPos;

    public CaptiveTrainCmd(Type enemyType,Type weaponType,  Vector3 spawnPos)
    {
        this.enemyType = enemyType;
        this.weaponType = weaponType;
        this.spawnPos = spawnPos;
    }


    public override void Execute()
    {
        Enemy enemy = FactoryManger.EnemyFactory.CreatCharacter(enemyType, weaponType, spawnPos) as Enemy;//创建俘兵
        GameFacade.Instance.CharacterSystem.RemoveEnemy(enemy);//从敌人list中移除

        SoldierCaptive captive = new SoldierCaptive(enemy);//创建适配器
        GameFacade.Instance.CharacterSystem.AddSoldier(captive);//加入到战士List

    }
}
