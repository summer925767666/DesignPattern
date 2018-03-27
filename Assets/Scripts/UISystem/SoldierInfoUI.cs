using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI : UISystem
{
    private Transform root;

    public override Transform Root
    {
        get { return root ?? (root = GameObject.Find("Canvas").transform.Find("SoldierInfo")); }
    }

    private Image soldierIcon;
    private Text soldierName;
    private Text soldierHP;
    private Slider soldierHPsSlider;
    private Text soldierLv;
    private Text soldierSpeed;
    private Text soldierAtk;
    private Text soldierAtkRange;

    protected override void Start()
    {
        soldierIcon = Root.Find("SoldierIcon").GetComponent<Image>();
        soldierName = Root.Find("SoldierName").GetComponent<Text>();
        soldierHP = Root.Find("SoldierHP").GetComponent<Text>();
        soldierHPsSlider = Root.Find("HPSlider").GetComponent<Slider>();
        soldierLv = Root.Find("SoldierLv").GetComponent<Text>();
        soldierSpeed = Root.Find("SoldierSpeed").GetComponent<Text>();
        soldierAtk = Root.Find("SoldierAtk").GetComponent<Text>();
        soldierAtkRange = Root.Find("SoldierAtkRange").GetComponent<Text>();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }
}