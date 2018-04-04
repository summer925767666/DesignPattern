//using System;
//using System.Timers;

//public class MyTimer
//{
//    private static Timer timer;
//    private static Action action;
//
//    public static void Invoke(Action ac, float t)
//    {
//        action = ac;
//
//        //设置时间间隔
//        //执行一次
//        //执行事件
//        timer = new Timer(t)
//        {
//            AutoReset = false,
//            Enabled = true
//        }; 
//        timer.Elapsed+=new ElapsedEventHandler(TimerEvent);
//        timer.Start();
//    }
//
//    private static void TimerEvent(object sender, ElapsedEventArgs e)
//    {
//        if (action!=null) { action(); }
//        timer.Stop();
//    }
//
//    public void Update()
//    {
//
//    }
//}