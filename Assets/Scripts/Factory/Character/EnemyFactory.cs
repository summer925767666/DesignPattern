using System;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public T CreatCharacter<T>(Type weaponType, Vector3 spawnPos, int lv = 1) where T : Character, new()
    {
        EnemyBuilder builder=new EnemyBuilder(typeof(T),weaponType,spawnPos,lv);
        return CharacterDirector.Construct(builder) as T;
    }
}

