using System;
using UnityEngine;

public abstract class BaseCamp
{
    private GameObject gameObject;
    private string name;
    private string iconName;
    private Type soldierType;
    private Vector3 spawnPos;
    private int trainCount; //正在训练的个数
    private float trainTime;
    private float timer;
    
    private IEnergyStrategy energyStrategy;

    public string Name
    {
        get { return name; }
    }

    public string IconName
    {
        get { return iconName; }
    }

    public abstract int Lv { get; }
    public abstract Type WeaponType { get; }
    protected abstract Command TrainCmd { get; }

    public int TrainCount
    {
        get { return trainCount; }
    }

    public float Timer
    {
        get { return timer; }
    }

    public abstract bool IsCanUpgradeCamp { get; }

    public int CampUpgradeCost
    {
        get { return energyStrategy.GetCampUpgradeCost(soldierType, Lv); }
    }

    public abstract bool IsCanUpgradeWeapon { get; }

    public int WeaponUpgradeCost
    {
        get { return energyStrategy.GetWeaponUpgradeCost(WeaponType); }
    }

    public int TrainCost
    {
        get { return energyStrategy.GetSoldierTrainCost(soldierType, Lv); }
    }

    protected BaseCamp(GameObject gameObject, string name, string iconName, Type soldierType, Vector3 spawnPos,
        float trainTime, IEnergyStrategy energyStrategy)
    {
        this.gameObject = gameObject;
        this.name = name;
        this.iconName = iconName;
        this.soldierType = soldierType;
        this.spawnPos = spawnPos;
        this.trainTime = trainTime;
        this.energyStrategy = energyStrategy;
    }

    public void Update()
    {
        TrainChecke();
    }

    public void Train()
    {
        trainCount++;
        timer = trainTime;
    }

    public void CancleTrain()
    {
        //需要生产的士兵数量归零，重置计时器
        trainCount = 0;
        timer = trainTime;
    }

    private void TrainChecke()
    {
        //判断是否有需要训练的士兵
        if (trainCount <= 0) return;

        //计时器判断
        timer -= Time.deltaTime;
        if (timer > 0) return;

        //执行命令
        if (TrainCmd != null)
        {
            TrainCmd.Execute();
        }

        //需要生产的士兵数量减一、重置计时器
        trainCount--;
        timer = trainTime;
    }

    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();
}