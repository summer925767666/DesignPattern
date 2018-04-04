public class AliveCountVisitor : CharacterVisitor
{
    public int EnemyCount { get; private set; }

    public int SoldierCount { get; private set; }

    public void Reset()
    {
        EnemyCount = SoldierCount = 0;
    }

    public override void VisitSoldier(Soldier soldier)
    {
        if (soldier.IsDead) return;

        SoldierCount++;
    }

    public override void VisitEnemy(Enemy enemy)
    {
        if (enemy.IsDead) return;

        EnemyCount++;
    }
}