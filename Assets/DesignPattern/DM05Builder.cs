using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DM05Builder:MonoBehaviour
{
    private void Start()
    {
        Person person= Director.ConstructPerson(new FatBuilder());
        person.Show();
    }



}

//产品部分的创建者，只负责各个部分的创建，但不负责产品的组装
public interface IBuilder
{
    void BuildHead();
    void BuildBody();
    void BuildFoot();
    void BuildHand();

    Person GetPerson();//得到结果
}

public class FatBuilder:IBuilder
{
    private FatPerson fatPerson=new FatPerson();

    public void BuildHead()
    {
        fatPerson.Head = "胖子头";
    }

    public void BuildBody()
    {
        fatPerson.Body = "胖子身体";
    }

    public void BuildFoot()
    {
        fatPerson.Foot = "胖子脚";
    }

    public void BuildHand()
    {
        fatPerson.Hand = "胖子手";
    }

    public Person GetPerson()
    {
        return fatPerson;
    }
}

public class ThinBuilder:IBuilder
{
    public void BuildHead()
    {
    }

    public void BuildBody()
    {
    }

    public void BuildFoot()
    {
    }

    public void BuildHand()
    {
    }

    public Person GetPerson()
    {
        return null;
    }
}

//指导者，将产品的组装逻辑和各个部分的创建解耦
public class Director
{
    public static Person ConstructPerson(IBuilder builder)
    {
        builder.BuildHead();
        builder.BuildBody();
        builder.BuildHand();
        builder.BuildFoot();

        return builder.GetPerson();
    }
}

//产品的抽象，只定义产品的各个部分，和各个部分的创建、各个部分的组装解耦
public abstract class Person
{
    public string Head { private get; set; }
    public string Body { private get; set; }
    public string Hand { private get; set; }
    public string Foot { private get; set; }

    public void Show()//演示用，非必须
    {
        Debug.Log(string.Format("{0}/{1}/{2}/{3}",Head,Body,Hand,Foot));
    }
}

public class FatPerson : Person
{
    
}

public class ThinPerson : Person
{
    
}
