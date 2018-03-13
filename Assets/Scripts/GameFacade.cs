using System.Collections.Generic;

//对于场景管理（外部）来说，Facade承担了外观者
//对于各游戏系统来说（内部），Facade承担了中介者
public class GameFacade
{
    #region 单例实现
    private static GameFacade instance = new GameFacade();
    public static GameFacade Instance { get { return instance; } }
    private GameFacade() { }
    #endregion

    private List<IGameSystem> systemList;

    private ArchievementSystem archievementSystem;
    private CampSystem campSystem;
    private CharacterSystem characterSystem;
    private EnergySystem energySystem;
    private GameEventSystem gameEventSystem;
    private StageSystem stageSystem;

    private CampInfoUI campInfoUI;
    private GamePauseUI gamePauseUI;
    private GameStateInfoUI gameStateInfoUI;
    private SoldierInfoUI soldierInfoUI;

    public void Init()
    {
        systemList=new List<IGameSystem>();

        archievementSystem=new ArchievementSystem();
        campSystem=new CampSystem();
        characterSystem = new CharacterSystem();
        energySystem=new EnergySystem();
        gameEventSystem=new GameEventSystem();
        stageSystem=new StageSystem();

        campInfoUI=new CampInfoUI();
        gamePauseUI=new GamePauseUI();
        gameStateInfoUI=new GameStateInfoUI();
        soldierInfoUI=new SoldierInfoUI();

        systemList.Add(archievementSystem);
        systemList.Add(campSystem);
        systemList.Add(characterSystem);
        systemList.Add(energySystem);
        systemList.Add(gameEventSystem);
        systemList.Add(stageSystem);

        systemList.Add(campInfoUI);
        systemList.Add(gamePauseUI);
        systemList.Add(gameStateInfoUI);
        systemList.Add(soldierInfoUI);

        systemList.ForEach(s=>s.Init());
    }

    public void Update()
    {
        systemList.ForEach(s => s.Update());
    }

    public void Release()
    {
        systemList.ForEach(s => s.Release());
    }

}