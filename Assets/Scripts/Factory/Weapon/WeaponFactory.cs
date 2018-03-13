using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

public class WeaponFactory
{
    public Weapon CreatWeapon(Type weaponType)
    {
        int atk = 0;
        float range = 0;
        GameObject go = FactoryManger.AssetFactory.LoadWeapon(weaponType.ToString());

        switch (weaponType.ToString())
        {
            case "WeaponGun":
                atk = 20;
                range = 5;
                break;

            case "WeaponRifle":
                atk = 30;
                range = 7;
                break;

            case "WeaponRocket":
                atk = 40;
                range = 8;
                break;
        }

        return Activator.CreateInstance(weaponType, atk, range, go) as Weapon;
    }

    public T CreatWeapon<T>() where T : Weapon
    {
        Type t = typeof(T);

        int atk = 0;
        float range = 0;
        GameObject go = FactoryManger.AssetFactory.LoadWeapon(t.ToString());

        switch (t.ToString())
        {
            case "WeaponGun":
                atk = 20;
                range = 5;
                break;

            case "WeaponRifle":
                atk = 30;
                range = 7;
                break;

            case "WeaponRocket":
                atk = 40;
                range = 8;
                break;
        }

        return Activator.CreateInstance(t, atk, range, go) as T;
    }
}