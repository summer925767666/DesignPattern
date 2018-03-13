using UnityEngine;
using UnityEngine.UI;

public class MainMenuState:BaseSceneState
{
    public MainMenuState(SceneStateController controller) : base("02MainMenuScene", controller)
    {
    }

    public override void StateStart()
    {
        GameObject.Find("Canvas/StartButton").GetComponent<Button>().onClick.AddListener(StartCallback);
    }

    private void StartCallback()
    {
        base.Controller.ChangeState(new BattleState(base.Controller));
    }
}
