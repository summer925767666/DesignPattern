using UnityEngine;
using UnityEngine.AI;

public abstract class Character
{
    #region Protected字段

    //数据
    protected CharacterAttribute _Attribute;

    //组件
    protected GameObject _GameObject;
    protected Animation _Ani;
    protected NavMeshAgent _NavMeshAgent;
    protected AudioSource _AudioSource;

    //武器
    protected Weapon _Weapon;

    #endregion

    #region Public属性

    //位置
    public Vector3 Position
    {
        get { return _GameObject == null ? Vector3.zero : _GameObject.transform.position; }
    }
    //攻击范围
    public float AtkRange
    {
        get { return _Weapon.AtkRange; }
    }
    //数值属性
    public CharacterAttribute Attribute
    {
        set { _Attribute = value; }
    }
    //游戏体
    public GameObject GameObject
    {
        set
        {
            _GameObject = value;
            _Ani = _GameObject.GetComponentInChildren<Animation>();
            _NavMeshAgent = _GameObject.GetComponent<NavMeshAgent>();
            _AudioSource = _GameObject.GetComponent<AudioSource>();
        }
    }
    //武器
    public Weapon Weapon
    {
        set
        {
            _Weapon = value;
            _Weapon.Owner = this;
            Transform weaponPoint = _GameObject.transform.Find
            ("Rookie/Bip001/Bip001 Pelvis/Bip001 Spine/Bip001 Spine1/Bip001 Spine2" +
             "/Bip001 Neck/Bip001 R Clavicle/Bip001 R UpperArm/Bip001 R Forearm/Bip001 R Hand/weapon-point");
            _Weapon.GameObject.transform.SetParent(_GameObject.transform);
            _Weapon.GameObject.transform.localPosition = Vector3.zero;
            _Weapon.GameObject.transform.AttachTo(weaponPoint);

        }
    }

    #endregion

    #region Protected方法

    //播放特效
    protected void PlayEffect(string name)
    {
        GameObject go = FactoryManger.AssetFactory.LoadEffect(name);
        go.transform.position = _GameObject.transform.position;
        go.AddComponent<DestoryForTime>();
    }

    //播放音效
    protected void PlaySound(string name)
    {
        AudioClip clip = FactoryManger.AssetFactory.LoadAudioClip(name);
        _AudioSource.clip = clip;
        _AudioSource.Play();
    }

    //被攻击
    protected virtual void TakeDamage(int dmg)
    {
        _Attribute.TakeDamage(dmg);
    }

    //死亡
    protected void Die()
    {

    }

    #endregion

    #region Public方法

    public void Update()
    {
        _Weapon.Update();
    }

    //攻击目标
    public void Attack(Character target)
    {
        _GameObject.transform.LookAt(target.Position); //朝向目标
        PlayAni("attack"); //播放攻击动画
        _Weapon.Fire(target.Position); //攻击特效
        target.TakeDamage(_Weapon.Atk + target._Attribute.CritValue); //被攻击目标处理伤害
    }

    //播放动画
    public void PlayAni(string name)
    {
        _Ani.CrossFade(name);
    }

    //追击
    public void Chase(Vector3 target)
    {
        _NavMeshAgent.SetDestination(target);
        PlayAni("move");
    }

    #endregion
}