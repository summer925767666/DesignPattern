using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StageSubject:GameSubject
{

    protected override void OnNotify(params object[] para)
    {
        base.Dispatch(para);
    }
}

