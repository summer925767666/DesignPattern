using UnityEngine;

/*状态模式
 * 类的行为和状态有关
 * 状态实现内部实现自动的状态切换
 */
public class DM01State : MonoBehaviour
{
    private void Start()
    {
        StateContext stateContext = new StateContext();
        stateContext.SetState(new ConcreteStateA(stateContext));

        stateContext.Handle(5);
        stateContext.Handle(10);
        stateContext.Handle(15);
        stateContext.Handle(1);
        stateContext.Handle(2);
    }
}

public class StateContext
{
    private IState state;

    public void SetState(IState s)
    {
        state = s;
    }

    public void Handle(int arg)
    {
        state.Handle(arg);
    }
}

public interface IState
{
    void Handle(int arg);
}

public class ConcreteStateA : IState
{
    private StateContext stateContext;

    public ConcreteStateA(StateContext stateContext)
    {
        this.stateContext = stateContext;
    }

    public void Handle(int arg)
    {
        Debug.Log("状态A逻辑处理" + arg);
        if (arg > 10)
        {
            stateContext.SetState(new ConcreteStateB(stateContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private StateContext stateContext;

    public ConcreteStateB(StateContext stateContext)
    {
        this.stateContext = stateContext;
    }

    public void Handle(int arg)
    {
        Debug.Log("状态B逻辑处理" + arg);
        if (arg <= 10)
        {
            stateContext.SetState(new ConcreteStateA(stateContext));
        }
    }
}