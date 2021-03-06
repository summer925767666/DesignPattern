﻿using System.Collections.Generic;
using UnityEngine;

public class StageSystem : IGameSystem,IGameObserver
{
    private int lv = 1;//当前关卡
    private StageHandler rootHandler;//责任链的根节点
    private Vector3 target;//敌人移动的目标点
    private List<Vector3> spawnPosList = new List<Vector3>();//出生点
    private int killedEnemyCount = 0;

    public Vector3 EnemyTarget { get { return target; } }

    public void Init()
    {
        //初始化位置
        InitPosition();

        //初始化关卡
        InitStageChain();

        GameFacade.Instance.EventSystem.Register(typeof(EnemyKilledSubject),this);
    }

    public void Update()
    {
        rootHandler.Handle(lv);
    }

    public void Release()
    {
    }

    private void InitPosition()
    {
        target = GameObject.Find("EnemyTarget").transform.position;

        foreach (Transform ts in GameObject.Find("EnemySpawn").transform)
        {
            spawnPosList.Add(ts.position);
            ts.gameObject.SetActive(false);
        }
    }

    private void InitStageChain()
    {
        int tempLv = 1;

        StageHandler handler1 = new NormalStageHandler(this, tempLv++, 3, typeof(EnemyElf), typeof(WeaponGun), 3,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler2 = new NormalStageHandler(this, tempLv++, 6, typeof(EnemyElf), typeof(WeaponRifle), 3,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler3 = new NormalStageHandler(this, tempLv++, 9, typeof(EnemyElf), typeof(WeaponRocket), 3,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler4 = new NormalStageHandler(this, tempLv++, 13, typeof(EnemyOgre), typeof(WeaponGun), 4,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler5 = new NormalStageHandler(this, tempLv++, 17, typeof(EnemyOgre), typeof(WeaponRifle), 4,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler6 = new NormalStageHandler(this, tempLv++, 21, typeof(EnemyOgre), typeof(WeaponRocket), 4,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler7 = new NormalStageHandler(this, tempLv++, 26, typeof(EnemyTroll), typeof(WeaponGun), 5,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler8 = new NormalStageHandler(this, tempLv++, 31, typeof(EnemyTroll), typeof(WeaponRifle), 5,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);
        StageHandler handler9 = new NormalStageHandler(this, tempLv++, 36, typeof(EnemyTroll), typeof(WeaponRocket), 5,
            spawnPosList[Random.Range(0, spawnPosList.Count - 1)]);

        handler1.SetNext(handler2)
            .SetNext(handler3)
            .SetNext(handler4)
            .SetNext(handler5)
            .SetNext(handler6)
            .SetNext(handler7)
            .SetNext(handler8)
            .SetNext(handler9);

        rootHandler = handler1;
    }

    public int GetDeadEnermyCount()
    {
       return killedEnemyCount;
    }

    public void EnterNextStage()
    {
        lv++;
        GameFacade.Instance.EventSystem.Notify(typeof(StageSubject),lv);
    }

    public void Update(params object[] para)
    {
        killedEnemyCount =  (int) para[0];
    }
}