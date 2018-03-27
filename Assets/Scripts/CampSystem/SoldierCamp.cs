using System;
using UnityEngine;

public class SoldierCamp : BaseCamp
{
    private const int MaxLV = 4;
    private const int MaxWeaponLv = 3;
    private int lv;
    private int weaponLv;
    private Type weaponType;
    private Command trainCmd;

    public override int Lv
    {
        get { return lv; }
    }

    public override Type WeaponType
    {
        get { return weaponType; }
    }

    protected override Command TrainCmd
    {
        get { return trainCmd; }
    }

    public override bool IsCanUpgradeCamp
    {
        get { return lv < MaxLV; }
    }

    public override bool IsCanUpgradeWeapon
    {
        get { return weaponLv < MaxWeaponLv; }
    }

    public SoldierCamp(GameObject gameObject, string name, string iconName, Type soldierType, Vector3 spawnPos,
        float trainTime, int lv = 1, Type weaponType = null)
        : base(gameObject, name, iconName, soldierType, spawnPos, trainTime, new SoldierEnergyStartegy())
    {
        this.lv = lv;
        this.weaponType = weaponType ?? typeof(WeaponGun);
        trainCmd=new SoldierTrainCmd(soldierType,this.weaponType,spawnPos,this.lv);
        weaponLv = FactoryManger.AttributeFactory.GetWeaponShareAttribute(this.weaponType).Lv;
    }

    public override void UpgradeCamp()
    {
        if (lv >= MaxLV)
        {
            Debug.Log("兵营已经升级到最大等级");
            return;
        }

        lv++;
    }

    public override void UpgradeWeapon()
    {
        if (weaponLv >= MaxWeaponLv)
        {
            Debug.Log("武器已经升级到最大等级");
            return;
        }

        weaponLv++;

        weaponType = FactoryManger.AttributeFactory.GetWeaponType(weaponLv);
    }


}