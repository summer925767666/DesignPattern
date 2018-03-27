using System;
using UnityEngine;

public class SoldierEnergyStartegy : IEnergyStrategy
{
    public int GetCampUpgradeCost(Type soldierType, int lv)
    {
        int energy = 0;

        switch (soldierType.ToString())
        {
            case "SoldierRookie":
                energy = 60;
                break;

            case "SoldierSergeant":
                energy = 65;
                break;
            case "SoldierCaptain":
                energy = 70;
                break;
            default:
                Debug.Log("升级兵营消耗,类型错误：" + soldierType);
                break;
        }

        energy += (lv - 1) * 2;
        energy = energy > 100 ? 100 : energy;

        return energy;
    }

    public int GetWeaponUpgradeCost(Type weaponType)
    {
        int energy = 0;

        switch (weaponType.ToString())
        {
            case "WeaponGun":
                energy = 30;
                break;
            case "WeaponRifle":
                energy = 40;
                break;
            default:
                Debug.LogError("升级武器消耗，类型错误：" + weaponType);
                break;
        }

        return energy;
    }

    public int GetSoldierTrainCost(Type soldierType, int lv)
    {
        int energy = 0;

        switch (soldierType.ToString())
        {
            case "SoldierRookie":
                energy = 10;
                break;

            case "SoldierSergeant":
                energy = 15;
                break;
            case "SoldierCaptain":
                energy = 20;
                break;
            default:
                Debug.LogError("升级士兵消耗,类型错误：" + soldierType);
                break;
        }

        energy += (lv - 1) * 2;
        energy = energy > 100 ? 100 : energy;

        return energy;
    }
}