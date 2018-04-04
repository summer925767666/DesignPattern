using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM11Visitor : MonoBehaviour
{
    private void Start()
    {
        DMCube cube=new DMCube();
        DMShpere shpere = new DMShpere();

        DMShapeContainer container = new DMShapeContainer();
        container.AddShape(cube);
        container.AddShape(shpere);

        DMAmountVisitor visitor = new DMAmountVisitor();

        container.RunVisitor(visitor);

        print(visitor.Amount);
    }
}

public class DMShapeContainer
{
    private List<DMShape> shapes = new List<DMShape>();

    public void AddShape(DMShape shape)
    {
        shapes.Add(shape);
    }

    public void RunVisitor(DMVisitor visitor)
    {
        shapes.ForEach(s=>s.RunVisitor(visitor));
    }
}

//具有稳定的数据机构，即图形的类别不会频繁变动，否则接口修改带来的修改成本过大
public abstract class DMShape
{
    public abstract void RunVisitor( DMVisitor visitor);
}

public class DMCube : DMShape
{
    public override void RunVisitor(DMVisitor visitor)
    {
        visitor.VisitCube(this);
    }
}

public class DMShpere : DMShape
{
    public override void RunVisitor(DMVisitor visitor)
    {
        visitor.VisitSphere(this);
    }
}

//封装了访问数据的方法，故成为访问者模式
public abstract class DMVisitor
{
    public abstract void VisitCube(DMCube cube);
    public abstract void VisitSphere(DMShpere shpere);
}

public class DMAmountVisitor : DMVisitor
{
    private int amount = 0;

    public int Amount { get { return amount; } }

    public override void VisitCube(DMCube cube)
    {
        amount++;
    }

    public override void VisitSphere(DMShpere shpere)
    {
        amount++;
    }
}


