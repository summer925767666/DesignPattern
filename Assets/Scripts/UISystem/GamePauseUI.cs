using UnityEngine;
using UnityEngine.UI;

class GamePauseUI:UISystem
{
    private Text stageText;
    private Button continueBtn;
    private Button exitBtn;

    public override void Init()
    {
        Root = GameObject.Find("Canvas").transform.Find("GamePause").gameObject;

        Transform root = Root.transform.Find("BG");
        stageText=root.Find("Stage").GetComponent<Text>();
        continueBtn = root.Find("Continue").GetComponent<Button>();
        exitBtn=root.Find("Exit").GetComponent<Button>();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }
}
