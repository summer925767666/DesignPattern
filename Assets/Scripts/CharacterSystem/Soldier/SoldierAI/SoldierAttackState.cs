using System.Linq;
using UnityEngine;

public class SoldierAttackState : SoldierState
{
    private float intervel = 1;
    private float timer = 0;

    public SoldierAttackState(SoldierFSMSystem system, Character character)
        : base(system, SoldierStateID.Attack, character)
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
        if (dis > Character.AtkRange)
        {
            System.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }

    public override void Act(SoldierStateData data)
    {
        var enemies = data.Enemies;

        if (enemies == null || enemies.Count <= 0)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer > 0) return;

        base.Character.Attack(enemies.First());
        timer = intervel;
    }

}