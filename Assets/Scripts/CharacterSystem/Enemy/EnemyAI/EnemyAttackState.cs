using System.Linq;
using UnityEngine;

public class EnemyAttackState:EnemyState
{
    private float intervel = 1;
    private float timer = 0;

    public EnemyAttackState(EnemyFSMSystem system, Character character) : base(system, EnemyStateID.Attack, character)
    {
    }

    public override void Reason(EnemyStateData data)
    {
        var soldiers = data.Soldiers;

        //判断有无战士
        if (soldiers == null || soldiers.Count <= 0)
        {
            System.PerformTransition(EnemyTransition.LostSoldier);
        }
        //判断是否在攻击范围内
        else if (Vector3.Distance(base.Character.Position, soldiers.First().Position) > base.Character.AtkRange)
        {
            base.System.PerformTransition(EnemyTransition.LostSoldier);
        }

    }

    public override void Act(EnemyStateData data)
    {
        //判断有无战士
        var soldiers = data.Soldiers;
        if (soldiers == null || soldiers.Count <= 0) return;

        //有战士，攻击第一个
        timer -= Time.deltaTime;
        if (timer > 0) return;
        base.Character.Attack(soldiers.First());
        timer = intervel;
    }
}

