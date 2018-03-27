using System;
using UnityEngine;

public class CharacterFactory:ICharacterFactory
{
    public Character CreatCharacter(Type characterType, Type weaponType, Vector3 spawnPos, int lv = 1)
    {
        AbstractCharacterBuilder builder = new CharacterBuilder(characterType, weaponType, spawnPos, lv);
        return CharacterDirector.Construct(builder);
    }
}

