using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : IGameSystem
{
    private Dictionary<Type, GameSubject> subjects = new Dictionary<Type, GameSubject>();

    public void Init()
    {

    }

    public void Update()
    {

    }

    public void Release()
    {

    }

    //注册指定类型的事件
    public void Register(Type subjectType, IGameObserver observer)
    {
        GetSubject(subjectType).Register(observer);
    }    
    
    //取消订阅指定类型的事件
    public void Remove(Type subjectType, IGameObserver observer)
    {
        GetSubject(subjectType).Remove(observer);
    }    
    
    //触发指定类型的事件
    public void Notify(Type subjectType,params object[] para)
    {
        GetSubject(subjectType).Notify(para);
    }

    private GameSubject GetSubject(Type type)
    {
        GameSubject subject;
        subjects.TryGetValue(type, out subject);

        if (subject == null)
        {
            subject = Activator.CreateInstance(type) as GameSubject;
            subjects.Add(type, subject);
        }

        return subject;
    }

}