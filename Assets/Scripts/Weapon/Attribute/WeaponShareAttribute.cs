using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WeaponShareAttribute
{
    public string Name { get; private set; }//武器名称
    public int Atk { get; private set; } //攻击力
    public float AtkRange { get; private set; }//攻击范围

    public string AssetName { get; private set; }//资源名

    public WeaponShareAttribute(string name, int atk, float atkRange, string assetName)
    {
        Name = name;
        Atk = atk;
        AtkRange = atkRange;
        AssetName = assetName;
    }
}

