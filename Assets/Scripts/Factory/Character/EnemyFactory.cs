using System;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
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
            case "EnemyElf":
                name = "小精灵";
                maxHP = 100;
                moveSpeed = 3;
                iconSprite = "ElfIcon";
                prefabName = "Enemy1";
                break;

            case "EnemyOgre":
                name = "怪物";
                maxHP = 120;
                moveSpeed = 4f;
                iconSprite = "OgreIcon";
                prefabName = "Enemy2";
                break;

            case "EnemyTroll":
                name = "巨怪";
                maxHP = 200;
                moveSpeed = 1;
                iconSprite = "TrollIcon";
                prefabName = "Enemy3";
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

        return character;
    }
}

