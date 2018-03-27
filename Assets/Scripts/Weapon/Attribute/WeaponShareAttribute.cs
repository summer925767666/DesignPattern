public class WeaponShareAttribute
{
    public string Name { get; private set; }//武器名称
    public int Atk { get; private set; } //攻击力
    public float AtkRange { get; private set; }//攻击范围
    public string AssetName { get; private set; }//资源名
    public int Lv { get; private set; }//等级

    public WeaponShareAttribute(string name, int atk, float atkRange, string assetName,int lv)
    {
        Name = name;
        Atk = atk;
        AtkRange = atkRange;
        AssetName = assetName;
        Lv = lv;
    }
}

