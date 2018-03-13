public class SoldierIdleState : SoldierState
{
    public SoldierIdleState(SoldierFSMSystem system, Character character)
        : base(system, SoldierStateID.Idle, character)
    {
    }

    public override void Reason(SoldierStateData data)
    {
        var enemies = data.Enemies;
        if (enemies != null && enemies.Count > 0)
        {
            System.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }

    public override void Act(SoldierStateData data)
    {
        base.Character.PlayAni("stand");
    }
}