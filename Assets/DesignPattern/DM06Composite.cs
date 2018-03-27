using System.Collections.Generic;
using UnityEngine;

public class DM06Composite : MonoBehaviour
{
    void Start()
    {
        MyCompoment _1stCom= new Composite("第一层Composite");

        MyCompoment _2rdCom=new Composite("第二层Composite");

        MyCompoment _2rdLeaf=new Leaf("第二层Leaf");

        MyCompoment _3rdLeaf=new Leaf("第三层Leaf");

        _1stCom.AddChild(_2rdCom);
        _1stCom.AddChild(_2rdLeaf);

        _2rdCom.AddChild(_3rdLeaf);

        _1stCom.Operation();
        print("\n");
        _2rdCom.Operation();
        print("\n");
        _2rdLeaf.Operation();

    }
}

public abstract class MyCompoment
{
    protected string Name { get; private set; }
    protected MyCompoment(string name)
    {
        Name = name;
    }
    public abstract void AddChild(MyCompoment compoment);
    public abstract void RemoveChild(MyCompoment compoment);
    public abstract void Operation();
}

public class Leaf : MyCompoment
{
    public Leaf(string name) : base(name)
    {
    }
    public override void AddChild(MyCompoment compoment)
    {
        Debug.Log("叶子不能添加子节点");
    }
    public override void RemoveChild(MyCompoment compoment)
    {
        Debug.Log("叶子不能移除子节点");
    }

    public override void Operation()
    {
        Debug.Log(base.Name);
    }
}

public class Composite : MyCompoment
{
    private List<MyCompoment> compoments;
    public Composite(string name) : base(name)
    {
        compoments = new List<MyCompoment>();
    }
    public override void AddChild(MyCompoment compoment)
    {
        compoments.Add(compoment);
    }
    public override void RemoveChild(MyCompoment compoment)
    {
        compoments.Remove(compoment);
    }

    public override void Operation()
    {
        Debug.Log(base.Name);
        compoments.ForEach(c=>c.Operation());
    }
}