using System;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public Character CreatCharacter(Type characterType, Type weaponType, Vector3 spawnPos, int lv = 1)
    {
        SoldierBuilder builder = new SoldierBuilder(characterType, weaponType, spawnPos, lv);
        Character soldier = CharacterDirector.Construct(builder);
        GameFacade.Instance.CharacterSystem.AddSoldier(soldier as Soldier);//添加到角色系统

        return soldier;
    }
}