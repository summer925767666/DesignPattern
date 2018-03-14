using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CharShareAttribute
{
    public string Name { get; private set; }//角色名称
    public int MaxHP { get; private set; }//固有血量
    public float MoveSpeed { get; private set; }//移动速度
    public string IconSprite { get; private set; }//角色头像
    public string PrefabName { get; private set; }//预制体名称
    public float CriRate { get; private set; }//被暴击率，被攻击时伤害暴击的几率，敌人属性
    public ICharAttributeStrategy Strategy { get; private set; }//加血、减伤、被暴击伤害

    public CharShareAttribute(string name,int maxHP,float moveSpeed,string iconSprite,string prefabName,float criRate,ICharAttributeStrategy strategy )
    {
        Name = name;
        MaxHP = maxHP;
        MoveSpeed = moveSpeed;
        IconSprite = iconSprite;
        PrefabName = prefabName;
        CriRate = criRate;
        Strategy = strategy;
    }
}

