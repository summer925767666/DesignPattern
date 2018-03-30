using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EnemyKilledSubject:GameSubject
{
    private int killedCount = 0;

    protected override void OnNotify(params object[] para)
    {
        killedCount++;
        base.Dispatch(killedCount);
    }
}

