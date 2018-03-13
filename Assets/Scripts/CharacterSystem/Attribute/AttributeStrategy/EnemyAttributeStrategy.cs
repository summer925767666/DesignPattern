using UnityEngine;

public class EnemyAttributeStrategy : IAttributeStrategy
{
    public int GetExtraHP(int lv)
    {
        return 0;
    }

    public int GetDescDmg(int lv)
    {
        return 0;
    }

    public int GetCriDmg(float criRate)
    {
        float temp = Random.Range(0, 1);

        return temp < criRate ? Random.Range(5, 10) : 0;
    }
}