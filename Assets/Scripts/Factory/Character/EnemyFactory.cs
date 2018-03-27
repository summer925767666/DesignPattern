using System;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public Character CreatCharacter(Type characterType, Type weaponType, Vector3 spawnPos, int lv = 1)
    {
        EnemyBuilder builder = new EnemyBuilder(characterType, weaponType, spawnPos, lv);
        Character enemy= CharacterDirector.Construct(builder);
        GameFacade.Instance.CharacterSystem.AddEnemy(enemy as Enemy);
        return enemy;
    }
}

