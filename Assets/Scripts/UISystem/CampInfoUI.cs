using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : UISystem
{
    private Image campIcon;
    private Text campName;
    private Text campLv;
    private Button campLvUpBtn;
    private Text weaponLv;
    private Button weaponLvUpBtn;
    private Button trainBtn;
    private Button cancleTrainBtn;
    private Text aliveCount;
    private Text trainingCount;
    private Text trainTime;

    private BaseCamp currentCamp;

    public override void Init()
    {
        Root = GameObject.Find("Canvas").transform.Find("CampInfo").gameObject;

        Transform root = Root.transform;
        campIcon = root.Find("CampIcon").GetComponent<Image>();
        campName = root.Find("CampName").GetComponent<Text>();
        campLv = root.Find("CampLv").GetComponent<Text>();
        campLvUpBtn = root.Find("CampLvUp").GetComponent<Button>();
        weaponLv = root.Find("WeaponLv").GetComponent<Text>();
        weaponLvUpBtn = root.Find("WeaponLvUp").GetComponent<Button>();
        trainBtn = root.Find("Train").GetComponent<Button>();
        cancleTrainBtn = root.Find("CancleTrain").GetComponent<Button>();
        aliveCount = root.Find("AliveCount").GetComponent<Text>();
        trainingCount = root.Find("TrainingCount").GetComponent<Text>();
        trainTime = root.Find("TrainTime").GetComponent<Text>();
    }

    public override void Update()
    {
    }

    public override void Release()
    {
    }

    public void ShowCampInfo(BaseCamp camp)
    {
        base.Root.SetActive(true);

        campIcon.sprite = FactoryManger.AssetFactory.LoadSprite(camp.IconName);
        campName.text = camp.Name;
        campLv.text = "兵营等级：" + camp.Lv;
        weaponLv.text = "武器等级：" + ShowWeapon(camp.WeaponLv);

        currentCamp = camp;
    }

    private string ShowWeapon(int lv)
    {
        string name = null;

        switch (lv)
        {
            case 1:
                name = "短枪";
                break;
            case 2:
                name = "长枪";
                break;
            case 3:
                name = "火箭";
                break;
        }

        return name;
    }
}