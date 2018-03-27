using UnityEngine;
using UnityEngine.UI;

class GamePauseUI:UISystem
{
    private Transform root;

    public override Transform Root
    {
        get { return root ?? (root = GameObject.Find("Canvas").transform.Find("GamePause")); }
    }

    private Text stageText;
    private Button continueBtn;
    private Button exitBtn;

    protected override void Start()
    {
        Transform bg = Root.transform.Find("BG");
        stageText = bg.Find("Stage").GetComponent<Text>();
        continueBtn = bg.Find("Continue").GetComponent<Button>();
        exitBtn = bg.Find("Exit").GetComponent<Button>();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }


}
