using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UITool
{

    public static GameObject GetCanvas(string name="Canvas")
    {
        return GameObject.Find(name);
    }


}

