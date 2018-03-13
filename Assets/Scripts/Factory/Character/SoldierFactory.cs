using System;
using System.Reflection;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public T CreatCharacter<T>(Type weaponType, Vector3 spawnPos, int lv = 1) where T : Character, new()
    {
        T character = Activator.CreateInstance(typeof(T)) as T;
        if (character == null)
        {
            return null;
        }

        //1、实例化数值属性
        string name = null;
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = null;
        string prefabName = null;

        switch (typeof(T).ToString())
        {
            case "SoldierCaptain":
                name = "上尉士兵";
                maxHP = 100;
                moveSpeed = 3;
                iconSprite = "CaptainIcon";
                prefabName = "Soldier1";
                break;

            case "SoldierRookie":
                name = "新手士兵";
                maxHP = 90;
                moveSpeed = 2.5f;
                iconSprite = "Rookie";
                prefabName = "Soldier2";
                break;

            case "SoldierSergeant":
                name = "中士士兵";
                maxHP = 90;
                moveSpeed = 3;
                iconSprite = "Sergeant";
                prefabName = "Soldier3";
                break;
            default:
                Debug.LogError("类型错误" + typeof(T));
                break;
        }

        CharacterAttribute attribute = new SoldierAttribute(name, maxHP, moveSpeed, iconSprite, prefabName, lv);
        character.Attribute = attribute;

        //2、实例化游戏体
        GameObject go = FactoryManger.AssetFactory.LoadSoldier(attribute.PrefabName);
        go.transform.position = spawnPos;
        character.GameObject = go;

        //3、实例化武器
        Weapon weapon = FactoryManger.WeaponFactory.CreatWeapon(weaponType);
        character.Weapon = weapon;

        #region 利用反射，实现Type类型转换为泛型T

        //        WeaponFactory weaponFactory = FactoryManger.WeaponFactory;
        //        var mi = weaponFactory.GetType().GetMethod("CreatWeapon").MakeGenericMethod(weaponType);
        //        mi.Invoke(weaponFactory,null);

        #endregion

        return character;
    }
}