using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    private BaseSceneState currentState;

    private AsyncOperation asyncOperation;
    private bool isRunStart;

    public BaseSceneState CurrentState { set { currentState = value; } }

    //设置当前的状态
    public void ChangeState(BaseSceneState state)
    {
        currentState.StateEnd(); //执行上一状态的end方法

        currentState = state; //切换状态

        asyncOperation = SceneManager.LoadSceneAsync(currentState.SceneName); //异步加载当前场景
        isRunStart = false;//异步执行当前状态的Start方法
    }

    public void StateUpdate()
    {
        if (asyncOperation!=null && asyncOperation.isDone ==false)//正在加载场景时，直接返回
        {
            return;
        }

        if (isRunStart == false)//如果加载完成场景，但是还未执行StateStart方法，执行StateStart方法
        {
            currentState.StateStart();
            isRunStart = true;
        }

        currentState.StateUpdate();//执行currentState的Update方法        
    }
}