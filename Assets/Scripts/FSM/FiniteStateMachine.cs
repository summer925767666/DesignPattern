using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//状态转换条件
public enum Transition
{
    NullTransition = 0,
}

//状态ID
public enum StateID
{
    NullStateID = 0,
}



//状态的抽象类
public abstract class FSMState
{
    protected FSMSystem system;
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();//所有的转换条件和转换状态的字典
    protected StateID stateID;//当前状态的状态ID

    //当前状态的状态ID
    public StateID ID
    {
        get { return stateID; }
    }

    public FSMState(FSMSystem system,StateID stateID)
    {
        this.system = system;
        this.stateID = stateID;
    }

    //添加状态转换键值对
    public void AddTransition(Transition trans, StateID id)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed for a real transition");
            return;
        }

        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSMState ERROR: NullState is not allowed for a real ID");
            return;
        }

        if (map.ContainsKey(trans))
        {
            Debug.LogError("FSMState ERROR: State " + stateID.ToString() + " already has transition " + trans.ToString() +
                           "Impossible to assign to another state");
            return;
        }

        map.Add(trans, id);
    }

    //删除状态转换键值对
    public void DeleteTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return;
        }

        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError("FSMState ERROR: Transition " + trans.ToString() + " passed to " + stateID.ToString() +
                       " was not on the state's transition list");
    }

    //根据转换条件，得到此状态在对应条件下的转换状态
    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
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
    public abstract void Reason(EnemyStateData data);

    //当前状态的表现，即在当前状态下要做的具体实现，由系统提供生命周期
    public abstract void Act(EnemyStateData data);
}

//状态机管理系统
public class FSMSystem
{
    private List<FSMState> states;//所有状态的List
    private StateID currentStateID;//当前状态ID
    private FSMState currentState;//当前状态
    public FSMSystem()
    {
        states = new List<FSMState>();
    }

    //添加状态到系统
    public void AddState(FSMState s)
    {
        if (s == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
            return;
        }

        //首次添加状态时，设置系统的初始数据，
        //执行状态的DoBeforeEntering方法
        if (states.Count == 0)
        {
            states.Add(s);
            currentState = s;
            currentStateID = s.ID;

            currentState.DoBeforeEntering();
            return;
        }

        if (states.Any(state => state.ID == s.ID))
        {
            Debug.LogError("FSM ERROR: Impossible to add state " + s.ID +
                           " because state has already been added");
            return;
        }
        states.Add(s);
    }

    //从系统中删除状态
    public void DeleteState(StateID id)
    {
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: NullState is not allowed for a real state");
            return;
        }

        foreach (FSMState state in states)
        {
            if (state.ID != id) continue;

            states.Remove(state);
            return;
        }
        Debug.LogError("FSM ERROR: Impossible to delete state " + id +
                       ". It was not on the list of states");
    }

    //执行状态转换
    public void PerformTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
            return;
        }

        StateID id = currentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: State " + currentStateID + " does not have a target state " +
                           " for transition " + trans);
            return;
        }

        currentStateID = id;
        foreach (FSMState state in states)
        {
            if (state.ID != currentStateID) continue;

            currentState.DoBeforeLeaving();//转换前执行现有状态的DoBeforeLeaving方法

            currentState = state;

            currentState.DoBeforeEntering();//转换完成，执行转换后状态的DoBeforeEntering方法
            break;
        }
    }

    public void Reason(EnemyStateData data)
    {
        currentState.Reason(data);
    }

    public void Act(EnemyStateData data)
    {
        currentState.Act(data);
    }
}