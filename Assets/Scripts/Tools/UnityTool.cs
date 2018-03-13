using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class UnityTool
{
    public static void AttachTo(this GameObject child, GameObject parent)
    {
        child.transform.AttachTo(parent.transform);
    }

    public static void AttachTo(this Transform child, Transform parent)
    {
        child.SetParent(parent);
        child.localPosition = Vector3.zero;
        child.localEulerAngles = Vector3.zero;
        child.localScale = Vector3.one;
    }
}

