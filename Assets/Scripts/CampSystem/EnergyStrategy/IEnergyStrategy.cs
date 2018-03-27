using System;

//能量消耗策略
public interface IEnergyStrategy
{
    int GetCampUpgradeCost(Type soldierType, int lv);

    int GetWeaponUpgradeCost(Type weaponType);

    int GetSoldierTrainCost(Type soldierType, int lv);
}

