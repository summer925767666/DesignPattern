using System.Collections.Generic;
using UnityEngine;

public class DM07Command : MonoBehaviour
{

    private DMCommand cmd;

	// Use this for initialization
	void Start () {

//        DMInvoker invoker=new DMInvoker();
//
//        invoker.AddCommand(new DMCommand1(new DMReceiver1()));
//
//	    invoker.ExecuteCmd();

        cmd=new DMCommand1(new DMReceiver1());

	    cmd.Execute();

	}
	
	// Update is called once per frame
	void Update () {



		
	}
}

public class DMInvoker
{
    private List<DMCommand> commands=new List<DMCommand>();

    public void AddCommand(DMCommand cmd)
    {
        commands.Add(cmd);
    }

    public void ExecuteCmd()
    {
        commands.ForEach(c=>c.Execute());

        commands.Clear();
    }

}

public abstract class DMCommand
{

    public abstract void Execute();
}


public class DMCommand1 : DMCommand
{
    private IReciever receiver;

    public DMCommand1(IReciever receiver)
    {
        this.receiver = receiver;
    }

    public override void Execute()
    {
        receiver.Action();
    }
}

public interface IReciever
{
    void Action();
}

public class DMReceiver1 :IReciever
{
    public void Action()
    {
        Debug.Log("Recieve1执行了cmd1命令");
    }
}

