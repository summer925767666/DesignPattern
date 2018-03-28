using System;
using UnityEngine;

public class SoldierBuilder: AbstractCharacterBuilder
{
    public SoldierBuilder(Type chatacterType, Type weaponType, Vector3 spawnPos, int lv) : base(chatacterType, weaponType, spawnPos, lv)
    {
    }

    public override void BuildAttribute()
    {
        //1、实例化数值属性
        CharacterAttribute attribute = new SoldierAttribute(FactoryManger.AttributeFactory.GetCharShareAttribute(base.CharacterType), base.Lv);
        base.Character.Attribute = attribute;
    }

    public override void BuildGameObject()
    {
        GameObject go = FactoryManger.AssetFactory.LoadSoldier(Character.Attribute.PrefabName);
        go.transform.position = SpawnPos;
        Character.GameObject = go;
    }
}

