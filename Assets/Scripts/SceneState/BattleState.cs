public class BattleState:BaseSceneState
{
    private GameFacade gameFacade = GameFacade.Instance;

    public BattleState( SceneStateController controller) : base("03BattleScene", controller)
    {

    }

    public override void StateStart()
    {
        gameFacade.Init();
    }

    public override void StateUpdate()
    {
        gameFacade.Update();
    }

    public override void StateEnd()
    {
        gameFacade.Release();
    }
}