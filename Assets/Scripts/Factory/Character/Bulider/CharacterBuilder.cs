using System;
using UnityEngine;

public class CharacterBuilder:AbstractCharacterBuilder
{
    public CharacterBuilder(Type chatacterType, Type weaponType, Vector3 spawnPos, int lv) : base(chatacterType, weaponType, spawnPos, lv)
    {
    }

    public override void BuildAttribute()
    {
        //1、实例化数值属性
        CharacterAttribute attribute = new CharacterAttribute(FactoryManger.AttributeFactory.GetCharShareAttribute(CharacterType),Lv);
        Character.Attribute = attribute;
    }
}

