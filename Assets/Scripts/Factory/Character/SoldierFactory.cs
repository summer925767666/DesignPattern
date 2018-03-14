using System;
using System.Reflection;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public T CreatCharacter<T>(Type weaponType, Vector3 spawnPos, int lv = 1) where T : Character, new()
    {
        SoldierBuilder builder=new SoldierBuilder(typeof(T),weaponType,spawnPos,lv);
        return CharacterDirector.Construct(builder) as T;
    }
}