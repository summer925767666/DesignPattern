using System.Collections.Generic;

public class CharacterSystem:IGameSystem
{
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

    private void UpdateEnemy()
    {
        enemies.ForEach(e =>
        {
            e.Update();
            e.UpdateFSM(new EnemyStateData { Soldiers = soldiers });
        });
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    private void UpdateSoldier()
    {
        soldiers.ForEach(s =>
        {
            s.Update();
            s.UpdateFSM(new SoldierStateData { Enemies = enemies });
        });
    }

    public void AddSoldier(Soldier soldier)
    {
        soldiers.Add(soldier);
    }

    public void RemoveSoldier(Soldier soldier)
    {
        soldiers.Remove(soldier);
    }
}
