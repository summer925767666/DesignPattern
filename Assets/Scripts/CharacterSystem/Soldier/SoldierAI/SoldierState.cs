using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition,
    SeeEnemy,
    CanAttack,
    NoEnemy,
}

public enum SoldierStateID
{
    NullStateID,
    Idle,
    Chase,
    Attack,
}

public struct SoldierStateData
{
    public List<Enemy> Enemies;
}


public abstract class SoldierState
{
    protected SoldierFSMSystem System;

    private readonly Dictionary<SoldierTransition, SoldierStateID> map =
        new Dictionary<SoldierTransition, SoldierStateID>(); //所有的转换条件和转换状态的字典

    private SoldierStateID StateID; //当前状态的状态ID

    protected Character Character;

    //当前状态的状态ID
    public SoldierStateID ID
    {
        get { return StateID; }
    }

    public SoldierState(SoldierFSMSystem system, SoldierStateID stateID,Character character)
    {
        System = system;
        StateID = stateID;
        Character = character;
    }

    //添加状态转换键值对
    public void AddTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("转换条件不能为NullTransition");
            return;
        }

        if (id == SoldierStateID.NullStateID)
        {
            Debug.LogError("转换状态不能为NullStateID");
            return;
        }

        if (map.ContainsKey(trans))
        {
            Debug.LogError("已经存在 " + trans);
            return;
        }

        map.Add(trans, id);
    }

    //删除状态转换键值对
    public void DeleteTransition(SoldierTransition trans)
    {
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("转换条件不存在");
    }

    //根据转换条件，得到此状态在对应条件下的转换状态
    public SoldierStateID GetOutputState(SoldierTransition trans)
    {
        return map.ContainsKey(trans) ? map[trans] : SoldierStateID.NullStateID;
    }

    //进入状态之前调用的方法
    public virtual void DoBeforeEntering()
    {
    }

    //离开状态之前调用的方法
    public virtual void DoBeforeLeaving()
    {
    }

    //状态内部实现状态转换条件的检测，并最终调用系统的PerformTransition方法，进行状态转换，由系统提供生命周期
    public abstract void Reason(SoldierStateData data);

    //当前状态的表现，即在当前状态下要做的具体实现，由系统提供生命周期
    public abstract void Act(SoldierStateData data);
}

//状态机管理系统
public class SoldierFSMSystem
{
    private List<SoldierState> states = new List<SoldierState>(); //所有状态的List
    private SoldierState currentState; //当前状态

    //添加多个状态到系统
    public void AddState(params SoldierState[] stateList)
    {
        foreach (var s in stateList)
        {
            AddState(s);
        }
    }

    //添加状态到系统
    public void AddState(SoldierState s)
    {
        if (s == null||s.ID==SoldierStateID.NullStateID)
        {
            Debug.LogError("添加状态不能为空");
            return;
        }

        //首次添加状态时，设置系统的初始数据，
        //执行状态的DoBeforeEntering方法
        if (states.Count == 0)
        {
            states.Add(s);
            currentState = s;

            currentState.DoBeforeEntering();
            return;
        }

        if (states.Any(state => state.ID == s.ID))
        {
            Debug.LogError("已经存在 " + s);
            return;
        }

        states.Add(s);
    }

    //从系统中删除状态
    public void DeleteState(SoldierStateID id)
    {
        foreach (SoldierState state in states)
        {
            if (state.ID != id) continue;

            states.Remove(state);
            return;
        }

        Debug.LogError("删除的状态不存在"+id);
    }

    //执行状态转换
    public void PerformTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("转换条件不能为空");
            return;
        }

        SoldierStateID nextId = currentState.GetOutputState(trans);
        if (nextId == SoldierStateID.NullStateID)
        {
            Debug.LogError("转换的状态不能为空");
            return;
        }

        foreach (SoldierState state in states)
        {
            if (state.ID != nextId) continue;

            currentState.DoBeforeLeaving(); //转换前执行现有状态的DoBeforeLeaving方法
            currentState = state;
            currentState.DoBeforeEntering(); //转换完成，执行转换后状态的DoBeforeEntering方法
            return;
        }
    }

    public void Reason(SoldierStateData data)
    {
        currentState.Reason(data);
    }

    public void Act(SoldierStateData data)
    {
        currentState.Act(data);
    }
}