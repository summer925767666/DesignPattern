using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM04Temple : MonoBehaviour {

	private void Start () 
    {
        BasePeople people=new NothPeople();
        people.Eat();

        people = new SouthPeople();
        people.Eat();

    }

}

public abstract class BasePeople
{

    public void Eat()
    {
        Order();
        EatSth();
        Pay();
    }

    private void Order()
    {
        Debug.Log("点单");
    }

    protected abstract void EatSth();

    private void Pay()
    {
        Debug.Log("付款");
    }
}

public class NothPeople : BasePeople
{
    protected override void EatSth()
    {
        Debug.Log("吃面食");
    }
}

public class SouthPeople : BasePeople
{
    protected override void EatSth()
    {
        Debug.Log("吃米饭");
    }
}


