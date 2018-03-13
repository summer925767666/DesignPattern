public class SoldierAttributeStrategy:IAttributeStrategy
{
    public int GetExtraHP(int lv)
    {
        return (lv - 1) * 10;
    }

    public int GetDescDmg(int lv)
    {
        return (lv - 1) * 5;
    }

    public int GetCriDmg(float criRate)
    {
        return 0;
    }
}

