using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM03Strategy : MonoBehaviour 
{
    private void Start()
    {
        StrategyContext context=new StrategyContext();
        context.Strategy=new StrategyA();
        context.Cal();
        context.Strategy = new StrategyB();
        context.Cal();
    }
}


public class StrategyContext
{
    public IStrategy Strategy;

    public void Cal()
    {
        Strategy.Cal();
    }
}

public interface IStrategy
{
    void Cal();
}

public class StrategyA : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用A策略");
    }
}

public class StrategyB : IStrategy
{
    public void Cal()
    {
        Debug.Log("使用B策略");
    }
}