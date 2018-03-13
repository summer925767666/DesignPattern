using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private Vector3 targetPos;

    public EnemyChaseState(EnemyFSMSystem system, Character character) : base(system, EnemyStateID.Chase, character)
    {
    }

    public override void DoBeforeEntering()
    {
        targetPos = Vector3.zero; //todo,关卡系统赋值目标位置
    }


    public override void Reason(EnemyStateData data)
    {
        var soldiers = data.Soldiers;

        //判断有无战士
        if (soldiers == null || soldiers.Count <= 0) return; 

        //判断是否在攻击范围内
        if (Vector3.Distance(base.Character.Position, soldiers.First().Position) <= base.Character.AtkRange)
        {
            base.System.PerformTransition(EnemyTransition.CanAttack);
        }
    }

    public override void Act(EnemyStateData data)
    {
        var soldiers = data.Soldiers;

        //有战士追战士，没战士追目标
        if (soldiers != null && soldiers.Count > 0)
        {
            base.Character.Chase(soldiers.First().Position);
        }
        else
        {
            base.Character.Chase(targetPos);
        }
    }
}