using UnityEngine;
using UnityEngine.AI;

public abstract class Character
{
    #region Private字段
    //组件
    private GameObject gameObject;
    private Animation ani;
    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;

    //武器
    private Weapon weapon;

    //销毁时间
    private readonly float DestroyTimer = 2f;

    #endregion

    #region Public属性

    //位置
    public Vector3 Position { get { return gameObject == null ? Vector3.zero : gameObject.transform.position; } }

    //攻击范围
    public float AtkRange { get { return weapon.AtkRange; } }

    //数值属性
    public CharacterAttribute Attribute { get; set; }

    //游戏体
    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
        set
        {
            gameObject = value;
            ani = gameObject.GetComponentInChildren<Animation>();
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            audioSource = gameObject.GetComponent<AudioSource>();
        }
    }

    //武器
    public Weapon Weapon
    {
        get { return weapon; }
        set
        {
            weapon = value;
            weapon.Owner = this;
            var weaponPoint = gameObject.transform.Find
            ("Bone/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2" +
             "/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/weapon-point");
            weapon.GameObject.transform.AttachTo(weaponPoint);
        }
    }

    public bool IsDead { get; private set; }

    #endregion

    #region Protected方法

    //播放特效
//    protected void PlayEffect(string name)
//    {
//        var go = FactoryManger.AssetFactory.LoadEffect(name);
//        go.transform.position = gameObject.transform.position;
//        go.AddComponent<DestoryForTime>();
//    }

    //播放音效
    protected void PlaySound(string name)
    {
        var clip = FactoryManger.AssetFactory.LoadAudioClip(name);
        audioSource.clip = clip;
        audioSource.Play();
    }

    //被攻击
    protected abstract void TakeDamage(int dmg);

    //死亡
    protected void Die()
    {
        IsDead = true;
        navMeshAgent.isStopped = true;
        Object.Destroy(gameObject, DestroyTimer);
    }

    #endregion

    #region Public方法

    public void Update() { weapon.Update(); }

    //攻击目标
    public void Attack(Character target)
    {
        gameObject.transform.LookAt(target.Position); //朝向目标
        PlayAni("attack"); //播放攻击动画
        weapon.Fire(target.Position); //攻击特效
        target.TakeDamage(weapon.Atk + target.Attribute.CritValue); //被攻击目标处理伤害
    }

    //播放动画
    public void PlayAni(string name) { ani.CrossFade(name); }

    //追击
    public void Chase(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
        PlayAni("move");
    }

    public abstract void RunVisitor(CharacterVisitor visitor);

    #endregion
}