using System;
using UnityEngine;

public class CaptiveCamp : BaseCamp
{
    private Command trainCmd;
    private Type weaponType;
    private readonly Type enemyType;

    public CaptiveCamp( string iconName, Type enemyType, Vector3 spawnPos,float trainTime) : 
        base( "俘兵兵营", iconName, typeof(SoldierCaptive), trainTime, new SoldierEnergyStartegy())
    {
        this.enemyType = enemyType;
        this.weaponType = typeof(WeaponGun);
        trainCmd = new CaptiveTrainCmd(this.enemyType, this.weaponType, spawnPos);
    }

    public override int Lv { get { return 1; } }

    public override Type WeaponType { get { return weaponType; } }

    protected override Command TrainCmd { get { return trainCmd; } }

    public override bool IsCanUpgradeCamp { get { return false; } }

    public override bool IsCanUpgradeWeapon { get { return false; } }

    public override void UpgradeCamp()
    {
        Debug.Log("俘兵营不能升级兵营");
        return;
    }

    public override void UpgradeWeapon()
    {
        Debug.Log("俘兵营不能升级武器");
        return;
    }
}