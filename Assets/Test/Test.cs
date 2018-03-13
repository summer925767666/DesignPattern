using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass1
{
    public int para;
}

public class MyClass2
{
    public MyClass1 m1;
}

public struct MyStruct
{
    public int Para;
    public MyClass1 MC;
}

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        MyStruct ms1=new MyStruct();
        MyClass1 mc1 = new MyClass1();

        ms1.MC = mc1;
        mc1.para = 10;

        print(ms1.MC.para);





    }
	

}
