using System;
using UnityEngine;

//大量重复代码，可以使用模版方法
public interface ICharacterFactory
{
    Character CreatCharacter(Type characterType,Type weaponType, Vector3 spawnPos, int lv = 1);
}