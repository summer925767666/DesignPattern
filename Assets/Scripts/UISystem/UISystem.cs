using UnityEngine;

public abstract class UISystem:IGameSystem
{
    protected GameFacade Facade;
    public abstract Transform Root { get; }

    public void Init()
    {
        Facade = GameFacade.Instance;
        Start();
    }

    protected virtual void Start()
    {
    }

    public virtual void Update()
    {

    }

    public virtual void Release()
    {
    }
}
