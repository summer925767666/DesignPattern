using UnityEngine;

public class AchievementSystem : IGameSystem
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

//    private CareTaker careTaker;

    public void Init()
    {
        GameFacade.Instance.EventSystem.Register(typeof(EnemyKilledSubject), enemy);
        GameFacade.Instance.EventSystem.Register(typeof(SoldierKilledSubject), soldier);
        GameFacade.Instance.EventSystem.Register(typeof(StageSubject), stage);
    }

    public void Update()
    {
    }

    public void Release()
    {
    }

    public Memento CreateMemento()
    {
        Memento memento = new Memento
        {
            EnemyKilledCount = enemy.EnemyKilledCount,
            SoldierKilledCount = soldier.SoldierKilledCount,
            MaxStageLv = stage.MaxStageLv
        };

        return memento;
    }

    public void RestoreMemento(IMemento m)
    {
        Memento memento = m as Memento;
        if (memento == null) return;


        enemy.EnemyKilledCount = memento.EnemyKilledCount;
        soldier.SoldierKilledCount = memento.SoldierKilledCount;
        stage.MaxStageLv = memento.MaxStageLv;
    }

    //备忘录的宽接口
    public class Memento : IMemento
    {
        public int EnemyKilledCount { get; set; }
        public int SoldierKilledCount { get; set; }
        public int MaxStageLv { get; set; }

        public void SaveToLocal()
        {
            PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
            PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
            PlayerPrefs.SetInt("MaxStageLv", MaxStageLv);
        }

        public void LoadFromLocal()
        {
            EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
            SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
            MaxStageLv = PlayerPrefs.GetInt("MaxStageLv",1);
        }
    }
}