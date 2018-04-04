using System.Collections.Generic;

public class CharacterSystem:IGameSystem
{
    private int deadEnemyCount = 0;
    private List<Enemy> enemies=new List<Enemy>();
    private List<Soldier> soldiers=new List<Soldier>();

    public void Init()
    {
    }

    public void Update()
    {
        UpdateEnemy();
        UpdateSoldier();
    }

    public void Release()
    {
    }

    //更新敌人的状态
    //更新敌人的有限状态机
    private void UpdateEnemy()
    {
        enemies.ForEach(e =>
        {
            e.Update();
            e.UpdateFSM(new EnemyStateData { Soldiers = soldiers });//在这里更新主要是因为需要士兵数据
        });
    }

    //添加敌人
    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    //移除敌人
    public void RemoveEnemy(Enemy enemy)
    {
        deadEnemyCount++;
        enemies.Remove(enemy);
    }

    //更新战士
    //更新战士的有限状态机
    private void UpdateSoldier()
    {
        soldiers.ForEach(s =>
        {
            s.Update();
            s.UpdateFSM(new SoldierStateData { Enemies = enemies });
        });
    }

    //添加战士
    public void AddSoldier(Soldier soldier)
    {
        soldiers.Add(soldier);
    }

    //移除战士
    public void RemoveSoldier(Soldier soldier)
    {
        soldiers.Remove(soldier);
    }

    //执行访问者
    public void RunVisitor(CharacterVisitor visitor)
    {
        soldiers.ForEach(s=>s.RunVisitor(visitor));
        enemies.ForEach(e=>e.RunVisitor(visitor));
    }
}
