using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController controller;        

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        controller=new SceneStateController();
        controller.CurrentState = new StartState(controller);
    }
	
	private void Update ()
	{
	    controller.StateUpdate();
	}
}
