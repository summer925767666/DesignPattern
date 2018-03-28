using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DM08ChainOfResponsibility:MonoBehaviour
{
    private void Start()
    {

        char problem = 'a';

//        switch (problem)
//        {
//            case 'a':
//                new DMHandleA().Handle(problem);
//                break;
//            case 'b':
//                new DMHandleB().Handle(problem);
//                break;
//        }

        DMHandler handlerA=new DMHandleA();
        DMHandler handlerB = new DMHandleB();
        DMHandler handlerC=new DMHandleC();

        handlerA.SetNext(handlerB).SetNext(handlerC);

        handlerA.Handle(problem);
    }
}

public abstract class DMHandler
{
    protected DMHandler NextHandler { get; private set; }

    public DMHandler SetNext(DMHandler handler)
    {
        NextHandler = handler;
        return NextHandler;
    }

    public abstract void Handle(char problem);

}

class DMHandleA:DMHandler
{
    public override void Handle(char problem)
    {
        if (problem=='a')
        {
            Debug.Log("处理了A问题");
        }
        else if(NextHandler!=null)
        {
            NextHandler.Handle(problem);
        }
        else
        {
            Debug.Log("NextHandle为空");
        }
    }
}

class DMHandleB : DMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'b')
        {
            Debug.Log("处理了B问题");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(problem);
        }
        else
        {
            Debug.Log("NextHandle为空");
        }
    }
}

class DMHandleC : DMHandler
{
    public override void Handle(char problem)
    {
        if (problem == 'c')
        {
            Debug.Log("处理了C问题");
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(problem);
        }
        else
        {
            Debug.Log("NextHandle为空");
        }
    }
}

