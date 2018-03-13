using System;
using UnityEngine;

public class EnemyBuilder:CharacterBuilder
{
    public EnemyBuilder(Type chatacterType, Type weaponType, Vector3 spawnPos, int lv) : base(chatacterType, weaponType, spawnPos, lv)
    {
    }

    public override void BuildAttribute()
    {
        //1、实例化数值属性
        string name = null;
        int maxHP = 0;
        float moveSpeed = 0;
        string iconSprite = null;
        string prefabName = null;


        switch (base.CharacterType.ToString())
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
                Debug.LogError("类型错误" + base.CharacterType);
                break;
        }

        CharacterAttribute attribute = new SoldierAttribute(name, maxHP, moveSpeed, iconSprite, prefabName, base.Lv);
        base.Character.Attribute = attribute;

    }
}

