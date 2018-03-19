using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

class GameStateInfoUI : UISystem
{
    private List<GameObject> hearts = new List<GameObject>();
    private Text soldierCount;
    private Text enemyCount;
    private Text stageInfo;
    private Button pauseBtn;
    private Slider energySlider;
    private GameObject gameOverUI;
    private Button exitBtn;
    private Text message;


    public override void Init()
    {
        Root = GameObject.Find("Canvas").transform.Find("GameStateInfo").gameObject;

        Transform root = Root.transform;
        root.Find("Hearts").GetComponentsInChildren<Transform>().ToList().ForEach(h => hearts.Add(h.gameObject));
        soldierCount = root.Find("SoldierCount").GetComponent<Text>();
        enemyCount = root.Find("EnemyCount").GetComponent<Text>();
        stageInfo = root.Find("StageInfo").GetComponent<Text>();
        pauseBtn = root.Find("Pause").GetComponent<Button>();
        energySlider = root.Find("EnergySlider").GetComponent<Slider>();
        gameOverUI = root.Find("GameOver").GetComponent<GameObject>();
        exitBtn = root.Find("GameOver/Button").GetComponent<Button>();
        message = root.Find("Message").GetComponent<Text>();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }
}