using System;
using UnityEngine;

public class WeaponFactory
{
    public Weapon CreatWeapon(Type weaponType)
    {
        WeaponShareAttribute attribute=FactoryManger.AttributeFactory.GetWeaponShareAttribute(weaponType);

        GameObject go = FactoryManger.AssetFactory.LoadWeapon(weaponType.ToString());

        return Activator.CreateInstance(weaponType,attribute, go) as Weapon;
    }
}