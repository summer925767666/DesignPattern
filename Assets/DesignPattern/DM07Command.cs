using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM07Command : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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


}

public abstract class DMCommand
{
    public abstract void Execute();
}


public class DMCommand1 : DMCommand
{
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }
}

public abstract class DMReceiver
{
    
}

public class DMReceiver1 : DMReceiver
{
    
}

