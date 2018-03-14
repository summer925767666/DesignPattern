using System;
using UnityEngine;

public class EnemyBuilder:AbstractCharacterBuilder
{
    public EnemyBuilder(Type chatacterType, Type weaponType, Vector3 spawnPos, int lv) : base(chatacterType, weaponType, spawnPos, lv)
    {
    }

    public override void BuildAttribute()
    {
        //1、实例化数值属性
        CharacterAttribute attribute = new EnemyAttribute(FactoryManger.AttributeFactory.GetCharShareAttribute(base.CharacterType), base.Lv);
        base.Character.Attribute = attribute;
    }
}

