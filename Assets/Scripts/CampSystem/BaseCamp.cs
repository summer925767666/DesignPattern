using System;
using UnityEngine;

public abstract class BaseCamp
{
    private readonly IEnergyStrategy energyStrategy;

    private readonly Type soldierType;

    private readonly float trainTime;

    protected BaseCamp(string name, string iconName, Type soldierType, float trainTime, IEnergyStrategy energyStrategy)
    {
        Name = name;
        IconName = iconName;
        this.soldierType = soldierType;
        this.trainTime = trainTime;
        this.energyStrategy = energyStrategy;
    }

    public string Name { get; private set; }

    public string IconName { get; private set; }

    public abstract int Lv { get; }
    public abstract Type WeaponType { get; }
    protected abstract Command TrainCmd { get; }

    public int TrainCount { get; private set; }

    public float Timer { get; private set; }

    public abstract bool IsCanUpgradeCamp { get; }

    public int CampUpgradeCost { get { return energyStrategy.GetCampUpgradeCost(soldierType, Lv); } }

    public abstract bool IsCanUpgradeWeapon { get; }

    public int WeaponUpgradeCost { get { return energyStrategy.GetWeaponUpgradeCost(WeaponType); } }

    public int TrainCost { get { return energyStrategy.GetSoldierTrainCost(soldierType, Lv); } }

    public void Update() { TrainChecke(); }

    public void Train()
    {
        TrainCount++;
        Timer = trainTime;
    }

    public void CancleTrain()
    {
        //需要生产的士兵数量归零，重置计时器
        TrainCount = 0;
        Timer = trainTime;
    }

    private void TrainChecke()
    {
        //判断是否有需要训练的士兵
        if (TrainCount <= 0) return;

        //计时器判断
        Timer -= Time.deltaTime;
        if (Timer > 0) return;

        //执行命令
        if (TrainCmd != null) TrainCmd.Execute();

        //需要生产的士兵数量减一、重置计时器
        TrainCount--;
        Timer = trainTime;
    }

    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();
}