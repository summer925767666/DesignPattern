public class CharacterAttribute
{
    protected string Name;//角色名称
    protected int MaxHP;//固有血量
    protected float MoveSpeed;//移动速度
    protected string IconSprite;//角色头像
    protected string _PrefabName;//预制体名称

    protected int Lv; //等级，主角属性
    protected IAttributeStrategy _Strategy;//加血、减伤、被暴击伤害
    protected int _CurrentHP;//当前血量
    protected int DesDmg;//减伤
    private float CriRate; //被暴击率，被攻击时伤害暴击的几率，敌人属性

    public int CurrentHp { get { return _CurrentHP; } }//当前血量
    public int CritValue { get { return _Strategy.GetCriDmg(CriRate); } }//被暴击伤害

    public string PrefabName { get { return _PrefabName; } }

    protected CharacterAttribute(string name,int maxHP,float moveSpeed,string iconSprite,string prefabName ,int lv, IAttributeStrategy strategy)
    {
        Name = name;
        MaxHP = maxHP;
        MoveSpeed = moveSpeed;
        IconSprite = iconSprite;
        _PrefabName = prefabName;
        Lv = lv;

        _Strategy = strategy;
        _CurrentHP = MaxHP + _Strategy.GetExtraHP(Lv);
        DesDmg = _Strategy.GetDescDmg(Lv);
    }

    public void TakeDamage(int dmg)
    {
        dmg -= DesDmg;
        dmg = dmg < 5 ? 5 : dmg;
        _CurrentHP -= dmg;
    }
}