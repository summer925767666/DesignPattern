using System.Linq;
using UnityEngine;

public class SoldierChaseState : SoldierState
{
    public SoldierChaseState(SoldierFSMSystem system,Character character) : base(system, SoldierStateID.Chase,character)
    {
    }

    public override void Reason(SoldierStateData data)
    {
        var enemies = data.Enemies;

        if (enemies == null || enemies.Count <= 0)
        {
            System.PerformTransition(SoldierTransition.NoEnemy);
            return;
        }

        float dis = Vector3.Distance(enemies.First().Position, Character.Position);
        if (dis<=Character.AtkRange)
        {
            System.PerformTransition(SoldierTransition.CanAttack);
        }
    }

    public override void Act(SoldierStateData data)
    {
        var enemies = data.Enemies;

        if (enemies != null && enemies.Count > 0)
        {
            base.Character.Chase(enemies.First().Position);
        }
    }

}