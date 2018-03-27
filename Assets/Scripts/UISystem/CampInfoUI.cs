using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI : UISystem
{
    private Transform root;

    public override Transform Root
    {
        get { return root ?? (root = GameObject.Find("Canvas").transform.Find("CampInfo")); }
    }

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

    private BaseCamp currentCamp; //放在这里不合适

    protected override void Start()
    {
        campIcon = Root.Find("CampIcon").GetComponent<Image>();
        campName = Root.Find("CampName").GetComponent<Text>();
        campLv = Root.Find("CampLv").GetComponent<Text>();
        campLvUpBtn = Root.Find("CampLvUp").GetComponent<Button>();
        weaponLv = Root.Find("WeaponLv").GetComponent<Text>();
        weaponLvUpBtn = Root.Find("WeaponLvUp").GetComponent<Button>();
        trainBtn = Root.Find("Train").GetComponent<Button>();
        cancleTrainBtn = Root.Find("CancleTrain").GetComponent<Button>();
        aliveCount = Root.Find("AliveCount").GetComponent<Text>();
        trainingCount = Root.Find("TrainingCount").GetComponent<Text>();
        trainTime = Root.Find("TrainTime").GetComponent<Text>();

        campLvUpBtn.onClick.AddListener(CampUpgradeBtnCallback);
        weaponLvUpBtn.onClick.AddListener(WeaponUpgradeBtnCallback);
        trainBtn.onClick.AddListener(TrainBtnCallback);
        cancleTrainBtn.onClick.AddListener(CancleTrainCallback);
    }

    public override void Update()
    {
        if (currentCamp == null) return;

        trainingCount.text = "正在训练：" + currentCamp.TrainCount;
        trainTime.text = "训练时间：" + currentCamp.Timer.ToString("0.00");
        cancleTrainBtn.interactable = currentCamp.TrainCount > 0;
    }

    public override void Release()
    {
    }

    public void ShowCampInfo(BaseCamp camp)
    {
        Root.gameObject.SetActive(true);

        campIcon.sprite = FactoryManger.AssetFactory.LoadSprite(camp.IconName);
        campName.text = camp.Name;
        campLv.text = "兵营等级：" + camp.Lv;
        weaponLv.text = "武器等级：" + FactoryManger.AttributeFactory.GetWeaponShareAttribute(camp.WeaponType).Name;

        currentCamp = camp;
    }

    //兵营升级按钮点击回调
    private void CampUpgradeBtnCallback()
    {
        if (currentCamp.IsCanUpgradeCamp == false)
        {
            Facade.GameStateInfoUI.ShowMsg("兵营已达到最大等级，无法升级");
            return;
        }

        if (Facade.EnergySystem.TakeEnergy(currentCamp.CampUpgradeCost))
        {
            currentCamp.UpgradeCamp();
            ShowCampInfo(currentCamp);
        }
        else
        {
            Facade.GameStateInfoUI.ShowMsg("能量不足" + currentCamp.CampUpgradeCost + "，无法升级兵营");
        }

        
    }

    //武器升级点击回调
    private void WeaponUpgradeBtnCallback()
    {
        if (currentCamp.IsCanUpgradeWeapon == false)
        {
            Facade.GameStateInfoUI.ShowMsg("武器已达到最大等级，无法升级");
            return;
        }

        if (Facade.EnergySystem.TakeEnergy(currentCamp.WeaponUpgradeCost))
        {
            currentCamp.UpgradeWeapon();
            ShowCampInfo(currentCamp);
        }
        else
        {
            Facade.GameStateInfoUI.ShowMsg("能量不足" + currentCamp.WeaponUpgradeCost + "，无法升级武器");
        }
        
    }

    //训练按钮点击回调
    private void TrainBtnCallback()
    {
        if (Facade.EnergySystem.TakeEnergy(currentCamp.TrainCost))
        {
            currentCamp.Train();
        }
        else
        {
            Facade.GameStateInfoUI.ShowMsg("能量不足" + currentCamp.TrainCost + "，无法训练");
        }
    }

    //取消按钮点击回调
    private void CancleTrainCallback()
    {
        Facade.EnergySystem.RecycleEnergy(currentCamp.TrainCost*currentCamp.TrainCount);
        currentCamp.CancleTrain();
    }
}