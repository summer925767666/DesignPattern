using System;
using UnityEngine;

public abstract class CharacterBuilder
{
    protected Type CharacterType { get; private set; }
    protected Type WeaponType { get; private set; }
    protected Vector3 SpawnPos { get; private set; }
    protected int Lv { get; private set; }

    protected Character Character { get; private set; }

    protected CharacterBuilder(Type chatacterType, Type weaponType,Vector3 spawnPos,int lv)
    {
        CharacterType = chatacterType;
        WeaponType = weaponType;
        SpawnPos = spawnPos;
        Lv = lv;

        Character = Activator.CreateInstance(CharacterType) as Character;

        if (Character == null)
        {
            Debug.LogError("类型错误" + CharacterType);
        }
    }

    //1、创建数值属性
    public abstract void BuildAttribute();

    //2、实例化游戏体
    public void BuildGameObject()
    {
        GameObject go = FactoryManger.AssetFactory.LoadSoldier(Character.Attribute.PrefabName);
        go.transform.position = SpawnPos;
        Character.GameObject = go;
    }

    //3、实例化武器
    public  void BuildWeapon()
    {
        Weapon weapon = FactoryManger.WeaponFactory.CreatWeapon(WeaponType);
        Character.Weapon = weapon;
    }

    public  Character GetCharacter()
    {
        return Character;
    }
}
