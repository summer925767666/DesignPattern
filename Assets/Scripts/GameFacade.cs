using System.Collections.Generic;

//对于场景管理（外部）来说，Facade承担了外观者
//对于各游戏系统来说（内部），Facade承担了中介者
public class GameFacade
{
    private AchievementSystem achievementSystem;

    private CampSystem campSystem;
    private GamePauseUI gamePauseUI;
    private SoldierInfoUI soldierInfoUI;

    private List<IGameSystem> systems;

    public CampInfoUI CampInfoUI { get; private set; }

    public GameStateInfoUI GameStateInfoUI { get; private set; }

    public CharacterSystem CharacterSystem { get; private set; }

    public EnergySystem EnergySystem { get; private set; }

    public StageSystem StageSystem { get; private set; }

    public GameEventSystem EventSystem { get; private set; }

    public void Init()
    {
        systems = new List<IGameSystem>();

        achievementSystem = new AchievementSystem();
        campSystem = new CampSystem();
        CharacterSystem = new CharacterSystem();
        EnergySystem = new EnergySystem();
        EventSystem = new GameEventSystem();
        StageSystem = new StageSystem();

        CampInfoUI = new CampInfoUI();
        gamePauseUI = new GamePauseUI();
        GameStateInfoUI = new GameStateInfoUI();
        soldierInfoUI = new SoldierInfoUI();

        systems.Add(achievementSystem);
        systems.Add(campSystem);
        systems.Add(CharacterSystem);
        systems.Add(EnergySystem);
        systems.Add(EventSystem);
        systems.Add(StageSystem);

        systems.Add(CampInfoUI);
        systems.Add(gamePauseUI);
        systems.Add(GameStateInfoUI);
        systems.Add(soldierInfoUI);

        systems.ForEach(s => s.Init());


        var memento = CareTaker.RetrieveMemento(); //取回备忘录
        achievementSystem.RestoreMemento(memento); //根据备忘录，恢复成就系统
    }

    public void Update()
    {
        systems.ForEach(s => s.Update());
    }

    public void Release()
    {
        systems.ForEach(s => s.Release());

        IMemento memento = achievementSystem.CreateMemento(); //成就系统创建备忘录
        CareTaker.SaveMemento(memento); //保存到备忘录
    }

    #region 单例实现

    private static readonly GameFacade instance = new GameFacade();

    public static GameFacade Instance { get { return instance; } }

    private GameFacade()
    {
    }

    #endregion
}