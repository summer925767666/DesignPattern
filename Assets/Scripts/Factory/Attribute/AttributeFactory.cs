using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributeFactory
{
    private Dictionary<Type, CharShareAttribute> charShareAttributes;
    private Dictionary<Type, WeaponShareAttribute> weaponShareAttributes;

    public AttributeFactory()
    {
        IniCharAttributes();
        IniWeaponAttributes();
    }

    private void IniCharAttributes()
    {
        charShareAttributes = new Dictionary<Type, CharShareAttribute>
        {
            {
                typeof(SoldierCaptain),
                new CharShareAttribute("上尉士兵", 100, 3, "CaptainIcon", "Soldier1", 0, new SoldierAttributeStrategy())
            },
            {
                typeof(SoldierSergeant),
                new CharShareAttribute("中士士兵", 90, 3, "SergeantIcon", "Soldier3", 0, new SoldierAttributeStrategy())
            },
            {
                typeof(SoldierRookie),
                new CharShareAttribute("新手士兵", 80, 2.5f, "RookieIcon", "Soldier2", 0, new SoldierAttributeStrategy())
            },
            {
                typeof(EnemyTroll),
                new CharShareAttribute("巨怪", 200, 1, "TrollIcon", "Enemy3", 0.4f, new EnemyAttributeStrategy())
            },
            {
                typeof(EnemyOgre),
                new CharShareAttribute("怪物", 120, 2, "CaptainIcon", "Soldier1", 0.3f, new EnemyAttributeStrategy())
            },
            {
                typeof(EnemyElf),
                new CharShareAttribute("小精灵", 100, 3, "CaptainIcon", "Soldier1", 0.2f, new EnemyAttributeStrategy())
            }
        };
    }

    private void IniWeaponAttributes()
    {
        weaponShareAttributes = new Dictionary<Type, WeaponShareAttribute>
        {
            {typeof(WeaponGun), new WeaponShareAttribute("霰弹枪", 20, 5, "WeaponGun",1)},
            {typeof(WeaponRifle), new WeaponShareAttribute("步枪", 30, 7, "WeaponRifle",2)},
            {typeof(WeaponRocket), new WeaponShareAttribute("火箭筒", 40, 8, "WeaponRocket",3)}
        };
    }

    public CharShareAttribute GetCharShareAttribute(Type characterType)
    {
        CharShareAttribute attribute;
        charShareAttributes.TryGetValue(characterType, out attribute);

        if (attribute==null)
        {
            Debug.Log("获取共享属性失败，类型："+characterType);
        }

        return attribute;
    }

    public WeaponShareAttribute GetWeaponShareAttribute(Type weaponType)
    {
        if (weaponType==null)
        {
            return null;
        }

        WeaponShareAttribute attribute;
        weaponShareAttributes.TryGetValue(weaponType, out attribute);

        if (attribute == null)
        {
            Debug.Log("获取共享属性失败，类型：" + weaponType);
        }

        return attribute;
    }

    public Type GetWeaponType(int weaponLv)
    {
        foreach (KeyValuePair<Type, WeaponShareAttribute> pair in weaponShareAttributes)
        {
            if (pair.Value.Lv==weaponLv)
            {
                return pair.Key;
            }
        }

        return null;
    }
}