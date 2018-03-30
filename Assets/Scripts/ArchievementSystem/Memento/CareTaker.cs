
//备忘录的管理者，持有备忘录的窄接口；
//保持原有数据的封装性
public class CareTaker
{
    //保存备忘录
    public static void SaveMemento(IMemento memento)
    {
        memento.SaveToLocal();//保存到本地
    }

    //取回备忘录
    public static IMemento RetrieveMemento()
    {
        IMemento memento=new AchievementSystem.Memento();
        memento.LoadFromLocal();//从本地加载
        return memento;
    } 
}

