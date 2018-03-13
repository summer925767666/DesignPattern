using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DestoryForTime:MonoBehaviour
{
    public float time = 1;

    private void Start()
    {
        DestroyObject(gameObject,time);
    }
}

