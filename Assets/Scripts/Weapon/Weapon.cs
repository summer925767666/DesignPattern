using UnityEngine;

public abstract class Weapon
{
    protected int _Atk; //攻击力
    protected float _AtkRange; //攻击范围
    protected float _AtkPlusValue; //暴击值
    protected Character _Owner; //武器持有者

    protected GameObject _GameObject; //武器游戏体
    protected ParticleSystem ParticleSystem; //枪口发射子弹特效
    protected LineRenderer LineRenderer; //子弹轨迹
    protected AudioSource AudioSource; //发射子弹声音
    protected Light Light; //

    protected float EffectTimer;

    public int Atk
    {
        get { return _Atk; }
    }

    public float AtkRange
    {
        get { return _AtkRange; }
    }

    public Character Owner
    {
        set { _Owner = value; }
    }

    public GameObject GameObject
    {
        get { return _GameObject; }
    }

    protected Weapon(int atk, float atkRange, GameObject gameObject)
    {
        this._Atk = atk;
        this._AtkRange = atkRange;
        this._GameObject = gameObject;

        Transform effect = gameObject.transform.Find("Effect");
        ParticleSystem = effect.GetComponent<ParticleSystem>();
        LineRenderer = effect.GetComponent<LineRenderer>();
        AudioSource = effect.GetComponent<AudioSource>();
        Light = effect.GetComponent<Light>();
    }

    public void Update()
    {
        if (EffectTimer <= 0)
        {
            return;
        }

        EffectTimer -= Time.deltaTime;

        if (EffectTimer <= 0)
        {
            DisableEffect();
        }
    }

    public void Fire(Vector3 target)
    {
        //显示枪口特效
        PlayMuzzleEffect();

        //显示子弹轨迹
        PlayBulletEffect(target);

        //设置特效显示时间
        SetEffectTimer();

        //播放声音
        PlaySound();
    }

    //显示枪口特效
    private void PlayMuzzleEffect()
    {
        ParticleSystem.Stop();
        ParticleSystem.Play();
        Light.enabled = true;
    }

    //显示子弹轨迹
    private void PlayBulletEffect(Vector3 target)
    {
        LineRenderer.enabled = true;
        LineRenderer.startWidth = GetLineWidth();
        LineRenderer.endWidth = GetLineWidth();
        LineRenderer.SetPosition(0, _GameObject.transform.position);
        LineRenderer.SetPosition(1, target);
    }

    protected abstract float GetLineWidth();

    //设置特效显示时间
    protected abstract void SetEffectTimer();

    //禁用特效
    protected void DisableEffect()
    {
        LineRenderer.enabled = false;
        Light.enabled = false;
    }

    //播放声音
    private void PlaySound()
    {
        string clipName = GetSoundName();
        AudioClip clip = FactoryManger.AssetFactory.LoadAudioClip(clipName);
        AudioSource.clip = clip;
        AudioSource.Play();
    }

    protected abstract string GetSoundName(); //只有一个参数，在实际开发中并没有使用模版方法模式的必要，这里强行使用只是为了学习而使用
}