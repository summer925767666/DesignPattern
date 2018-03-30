using System.Collections.Generic;

public abstract class GameSubject
{
    private List<IGameObserver> observers = new List<IGameObserver>();

    public void Register(IGameObserver observer)
    {
        observers.Add(observer);
    }

    public void Remove(IGameObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(params object[] para)
    {
        OnNotify(para);
    }

    protected abstract void OnNotify(params object[] para);

    protected void Dispatch(params object[] para)
    {
        observers.ForEach(ob => ob.Update(para));
    }

}

