
using UnityEngine;
using UnityEngine.UI;

public class SoldierInfoUI:UISystem
{
    private Image soldierIcon;
    private Text soldierName;
    private Text soldierHP;
    private Slider soldierHPsSlider;
    private Text soldierLv;
    private Text soldierSpeed;
    private Text soldierAtk;
    private Text soldierAtkRange;

    public override void Init()
    {
        Root = GameObject.Find("Canvas").transform.Find("SoldierInfo").gameObject;

        Transform root = Root.transform;
        soldierIcon=root.Find("SoldierIcon").GetComponent<Image>();
        soldierName = root.Find("SoldierName").GetComponent<Text>();
        soldierHP = root.Find("SoldierHP").GetComponent<Text>();
        soldierHPsSlider = root.Find("HPSlider").GetComponent<Slider>();
        soldierLv = root.Find("SoldierLv").GetComponent<Text>();
        soldierSpeed = root.Find("SoldierSpeed").GetComponent<Text>();
        soldierAtk = root.Find("SoldierAtk").GetComponent<Text>();
        soldierAtkRange = root.Find("SoldierAtkRange").GetComponent<Text>();


    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }
}
