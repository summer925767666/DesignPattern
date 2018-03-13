using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class DebugPath : EditorWindow
{
    private static string path;

    [MenuItem("GameObject/DebugObjectPath", priority = 49)]
    public static void DebugObjectPath()
    {
        GameObject go = Selection.activeGameObject;
        if (go==null)
        {
            return;
        }

        path = "";
        GetPath(go);
        Debug.Log(path);
    }

    private static string GetPath(GameObject go)
    {
        if (path == "")
        {
            path += go.name;
        }
        else
        {
            path = go.name + "/" + path;
        }

        return go.transform.parent == null ? path : GetPath(go.transform.parent.gameObject);
    }
}