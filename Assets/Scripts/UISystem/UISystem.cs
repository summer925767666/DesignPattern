using UnityEngine;

public abstract class UISystem:IGameSystem
{
    public GameObject Root { get; set; }

    public virtual void Init()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Release()
    {
    }
}
