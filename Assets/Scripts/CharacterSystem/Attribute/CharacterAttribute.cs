public class CharacterAttribute
{
    protected CharShareAttribute CharShareAttribute;

    protected int Lv; //等级，主角属性
    protected int _CurrentHP;//当前血量
    protected int DesDmg;//减伤

    public int CurrentHp { get { return _CurrentHP; } }//当前血量
    public int CritValue { get { return CharShareAttribute.Strategy.GetCriDmg(CharShareAttribute.CriRate); } }//被暴击伤害
    public string PrefabName { get { return CharShareAttribute.PrefabName; } }//预制体名字

    public CharacterAttribute(CharShareAttribute charShareAttribute, int lv)
    {
        CharShareAttribute = charShareAttribute;
        Lv = lv;

        _CurrentHP = CharShareAttribute.MaxHP + CharShareAttribute.Strategy.GetExtraHP(Lv);
        DesDmg = CharShareAttribute.Strategy.GetDescDmg(Lv);
    }

    public void TakeDamage(int dmg)
    {
        dmg -= DesDmg;
        dmg = dmg < 5 ? 5 : dmg;
        _CurrentHP -= dmg;
    }
}