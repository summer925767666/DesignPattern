using UnityEngine;
using UnityEngine.UI;

public class StartState:BaseSceneState
{
    private Image logo;
    private float smoothingSpeed = 1f;
    private float timer = 2;

    public StartState( SceneStateController controller) : base("01StartScene", controller)
    {
    }

    public override void StateStart()
    {
        logo = GameObject.Find("Canvas/Logo").GetComponent<Image>();
        logo.color = Color.black;
    }

    public override void StateUpdate()
    {
        logo.color = Color.Lerp(logo.color, Color.white, smoothingSpeed * Time.deltaTime);

        timer -= Time.deltaTime;
        if (timer<=0)
        {
            base.Controller.ChangeState(new MainMenuState(base.Controller));
        }
    }
}
