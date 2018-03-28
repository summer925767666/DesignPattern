public abstract class StageHandler
{
    private int lv;
    private int finishCount;
    private StageHandler nextHandler;
    private StageSystem stageSystem;
    public StageHandler SetNext(StageHandler handler)
    {
        nextHandler = handler;
        return nextHandler;
    }

    protected StageHandler(StageSystem system, int lv, int finishCount)
    {
        stageSystem = system;
        this.lv = lv;
        this.finishCount = finishCount;
    }


    public void Handle(int lv)
    {
        if (lv == this.lv)
        {
            UpdateStage();
            IsFinished();
        }
        else
        {
            nextHandler.Handle(lv);
        }
    }

    protected abstract void UpdateStage();

    private void IsFinished()
    {
        if (stageSystem.GetDeadEnermyCount() >= finishCount)
        {
            stageSystem.EnterNextStage();
        }
    }
}