using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameStateInfoUI : UISystem
{
    private Transform root;

    public override Transform Root
    {
        get { return root ?? (root = GameObject.Find("Canvas").transform.Find("GameStateInfo")); }
    }

    private List<GameObject> hearts = new List<GameObject>();
    private Text soldierCount;
    private Text enemyCount;
    private Text stageInfo;
    private Button pauseBtn;
    private Slider energySlider;
    private Text energtText;
    private GameObject gameOverUI;
    private Button exitBtn;
    private Text message;

    private float msgTimer;
    private float msgTime = 1;

    protected override void Start()
    {
        Root.Find("Hearts").GetComponentsInChildren<Transform>().ToList().ForEach(h => hearts.Add(h.gameObject));
        soldierCount = Root.Find("SoldierCount").GetComponent<Text>();
        enemyCount = Root.Find("EnemyCount").GetComponent<Text>();
        stageInfo = Root.Find("StageInfo").GetComponent<Text>();
        pauseBtn = Root.Find("Pause").GetComponent<Button>();
        energySlider = Root.Find("EnergySlider").GetComponent<Slider>();
        energtText=Root.Find("EnergySlider/Text").GetComponent<Text>();
        gameOverUI = Root.Find("GameOver").GetComponent<GameObject>();
        exitBtn = Root.Find("GameOver/Button").GetComponent<Button>();
        message = Root.Find("Message").GetComponent<Text>();
    }

    public override void Update()
    {
        msgTimer -= Time.deltaTime;
        if (msgTimer <= 0)
        {
            message.text = "";
        }
    }


    public override void Release()
    {
    }

    //显示提示信息
    public void ShowMsg(string msg)
    {
        message.text = msg;
        msgTimer = msgTime;
    }

    //更新能量显示
    public void UpdateEnergy(float current, int max)
    {
        energySlider.value = current / max;
        energtText.text = current.ToString("####") + "/" + max;
    }
}