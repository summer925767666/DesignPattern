using System;
using UnityEngine;

public class SoldierBuilder: CharacterBuilder
{
    public SoldierBuilder(Type chatacterType, Type weaponType, Vector3 spawnPos, int lv) : base(chatacterType, weaponType, spawnPos, lv)
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
                Debug.LogError("类型错误" + CharacterType);
                break;
        }

        base.Character.Attribute=new SoldierAttribute(name,maxHP,moveSpeed,iconSprite,prefabName,base.Lv);
    }




}

