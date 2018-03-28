using System;
using UnityEngine;

public class NormalStageHandler:StageHandler
{
    //todo,这些变量放在父类还是子类
    private Type enemyType;
    private Type weaponType;

    private readonly int maxCount;//当前关卡生成的敌人数量
    private Vector3 spawnPos;

    private readonly int spawnTime = 2;
    private float spawnTimer;
    private int curCount;

    public NormalStageHandler(StageSystem stageSystem, int lv, int finishCount, Type enemyType, Type weaponType, int maxCount, Vector3 spawnPos) : base(stageSystem, lv, finishCount)
    {
        this.enemyType = enemyType;
        this.weaponType = weaponType;
        this.maxCount = maxCount;
        this.spawnPos = spawnPos;
    }

    protected override void UpdateStage()
    {
        //判断是否已经生成了足够的敌人
        if (curCount >= maxCount) return;

        //计时器计时
        spawnTimer -= Time.deltaTime;
        if (spawnTimer > 0) return;

        //生成敌人
         FactoryManger.EnemyFactory.CreatCharacter(enemyType,weaponType,spawnPos);

        spawnTimer = spawnTime;//重置计时
        curCount++;//数量自增

    }
}

