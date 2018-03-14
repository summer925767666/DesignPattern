using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CharacterFactory:ICharacterFactory
{
    public T CreatCharacter<T>(Type weaponType, Vector3 spawnPos, int lv = 1) where T : Character, new()
    {
        AbstractCharacterBuilder builder=new CharacterBuilder(typeof(T),weaponType,spawnPos,lv);
        return CharacterDirector.Construct(builder) as T;
    }
}

