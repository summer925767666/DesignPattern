using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI : UISystem
{
    private Text enemyCount;
    private Text energtText;
    private Slider energySlider;
    private Button exitBtn;
    private GameObject gameOverUI;

    private readonly List<GameObject> hearts = new List<GameObject>();
    private Text message;
    private readonly float msgTime = 1;

    private float msgTimer;
    private Button pauseBtn;
    private Transform root;
    private Text soldierCount;
    private Text stageInfo;

    private AliveCountVisitor visitor = new AliveCountVisitor();

    public override Transform Root
    {
        get { return root ?? (root = GameObject.Find("Canvas").transform.Find("GameStateInfo")); }
    }

    protected override void Start()
    {
        Root.Find("Hearts").GetComponentsInChildren<Transform>().ToList().ForEach(h => hearts.Add(h.gameObject));
        soldierCount = Root.Find("SoldierCount").GetComponent<Text>();
        enemyCount = Root.Find("EnemyCount").GetComponent<Text>();
        stageInfo = Root.Find("StageInfo").GetComponent<Text>();
        pauseBtn = Root.Find("Pause").GetComponent<Button>();
        energySlider = Root.Find("EnergySlider").GetComponent<Slider>();
        energtText = Root.Find("EnergySlider/Text").GetComponent<Text>();
        gameOverUI = Root.Find("GameOver").GetComponent<GameObject>();
        exitBtn = Root.Find("GameOver/Button").GetComponent<Button>();
        message = Root.Find("Message").GetComponent<Text>();
    }

    public override void Update()
    {
        UpdateAliveCount();//更新存活角色数量
        ResetMsg();//自动隐藏提示信息
    }


    public override void Release()
    {
    }

    //显示提示信息
    public void ShowMsg(string msg)
    {
        msgTimer = msgTime;
        message.text = msg;
    }

    private void ResetMsg()
    {
        if (msgTimer <= 0) { return; }
        msgTimer -= Time.deltaTime;
        if (msgTimer <= 0) message.text = "";
    }


    //更新能量显示
    public void UpdateEnergy(float current, int max)
    {
        energySlider.value = current / max;
        energtText.text = current.ToString("####") + "/" + max;
    }

    //更新存货的角色数量
    private void UpdateAliveCount()
    {
        visitor.Reset();
        Facade.CharacterSystem.RunVisitor(visitor);

        enemyCount.text = "敌人数量：" + visitor.EnemyCount;
        soldierCount.text = "战士数量：" + visitor.SoldierCount;
    }
}