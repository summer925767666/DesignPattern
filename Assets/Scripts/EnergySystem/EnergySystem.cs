using UnityEngine;

public class EnergySystem:IGameSystem
{
    private const int MaxEnergy = 100;
    private float currentEnergy = MaxEnergy;
    private float recoverySpeed = 3;


    public void Init()
    {

    }

    public void Update()
    {
        currentEnergy += recoverySpeed * Time.deltaTime;
        currentEnergy = Mathf.Min(currentEnergy,MaxEnergy);
        GameFacade.Instance.GameStateInfoUI.UpdateEnergy(currentEnergy,MaxEnergy);
    }

    public void Release()
    {
    }

    //取得能量
    public bool TakeEnergy(int value )
    {
        if (!(currentEnergy >= value)) return false;

        currentEnergy -= value;
        return true;
    }

    public void RecycleEnergy(int value)
    {
        currentEnergy += value;
        currentEnergy=Mathf.Min(currentEnergy,MaxEnergy);
    }
}
