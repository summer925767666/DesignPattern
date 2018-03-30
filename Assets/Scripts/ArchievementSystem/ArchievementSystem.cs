using UnityEngine;

public class ArchievementSystem : IGameSystem
{
    private class Enemy : IGameObserver
    {
        public int EnemyKilledCount { get; set; }

        public void Update(params object[] para)
        {
            EnemyKilledCount++;
            Debug.Log("敌人" + EnemyKilledCount);
        }

        public void Test()
        {
            
        }
    }

    private class Soldier : IGameObserver
    {
        public int SoldierKilledCount { get; set; }

        public void Update(params object[] para)
        {
            SoldierKilledCount++;
            Debug.Log("士兵" + SoldierKilledCount);
        }
    }

    private class Stage : IGameObserver
    {
        public int MaxStageLv { get; set; }

        public void Update(params object[] para)
        {
            MaxStageLv = Mathf.Max(MaxStageLv, (int) para[0]);
            Debug.Log("关卡" + MaxStageLv);
        }
    }

    private Enemy enemy = new Enemy();
    private Soldier soldier = new Soldier();
    private Stage stage = new Stage();

    public void Init()
    {
        GameFacade.Instance.EventSystem.Register(typeof(EnemyKilledSubject), enemy);
        GameFacade.Instance.EventSystem.Register(typeof(SoldierKilledSubject), soldier);
        GameFacade.Instance.EventSystem.Register(typeof(StageSubject), stage);

        LoadData();
    }

    public void Update()
    {
    }

    public void Release()
    {
        SaveData();
    }

    private void SaveData()
    {
        AchievementMemento memento = new AchievementMemento
        {
            EnemyKilledCount = enemy.EnemyKilledCount,
            SoldierKilledCount = soldier.SoldierKilledCount,
            MaxStageLv = stage.MaxStageLv
        };

        memento.SaveData();
    }

    public void LoadData()
    {
        AchievementMemento memento=new AchievementMemento();
        memento.LoadData();

        enemy.EnemyKilledCount = memento.EnemyKilledCount;
        soldier.SoldierKilledCount = memento.SoldierKilledCount;
        stage.MaxStageLv = memento.MaxStageLv;
    }


}