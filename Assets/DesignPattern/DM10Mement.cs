using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DM10Mement : MonoBehaviour
{
    private void Start()
    {
        //创建originator类，并对状态赋值
        DMOriginator originator=new DMOriginator();
        originator.Lv = 10;

        print("初始值"+originator.Lv);

        //创建careTaker类，并保存此时originator的状态
        DMCareTaker careTaker=new DMCareTaker();
        careTaker.SaveMemento(originator.CreaterMemento());

        //设置originator的状态为其他值
        originator.Lv = 5;
        print("重置值" + originator.Lv);

        //从备忘中恢复originator原来的值
        originator.RestoreMemento(careTaker.RetrieveMemento());

        print("回复值" + originator.Lv);

    }
}

public class DMOriginator
{
    private int lv;

    public int Lv
    {
        get { return lv; }
        set { lv = value; }
    }

    public DMIMemento CreaterMemento()
    {
        DMMemento memento = new DMMemento {Lv = lv};
        return memento;
    }

    public void RestoreMemento(DMIMemento memento)
    {
        lv = ((DMMemento) memento).Lv;
    }

    private class DMMemento : DMIMemento
    {
        private int lv;

        public int Lv
        {
            get { return lv; }
            set { lv = value; }
        }
    }
}

public interface DMIMemento
{
}

public class DMCareTaker
{
    private DMIMemento memento;

    public void SaveMemento(DMIMemento m)
    {
        memento = m;
    }

    public DMIMemento RetrieveMemento()
    {
        return memento;
    }
}