using System.Collections.Generic;
using UnityEngine;

public class DM09Abserver : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        ConcreteSubject subject = new ConcreteSubject();
        Observer observer=new ConcreteObserver();

        subject.AddObserver(observer);
        subject.State = "下雨";
        subject.State = "下雪";



    }

    // Update is called once per frame
    void Update()
    {
    }
}

public abstract class Subject
{
    private List<Observer> observers=new List<Observer>();

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    protected void Notify(params object[] para)
    {
        observers.ForEach(ob => ob.Update(para));
    }    
}

public abstract class Observer
{
    public abstract void Update(params object[] para);

}

public class ConcreteSubject : Subject
{
    private string state;

    public string State
    {
        set
        {
            state = value;
            Notify(state);
        }
    }
}

public class ConcreteObserver : Observer
{
    public override void Update(params object[] para)
    {
        Debug.Log(para[0]);
    }
}