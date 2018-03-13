public class BaseSceneState
{
    protected readonly SceneStateController Controller;
    public string SceneName { get; private set; }

    protected BaseSceneState(string sceneName,SceneStateController controller)
    {
        SceneName = sceneName;
        Controller = controller;
    }

    public virtual void StateStart()
    {
    }


    public virtual void StateUpdate()
    {
    }

    public virtual void StateEnd()
    {
    }
}