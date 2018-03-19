using UnityEngine;
using Object = UnityEngine.Object;

public class ResourcesAssetFactory : IAssetFactory
{
    private const string SoldierPath = "Characters/Soldier/";
    private const string EnemyrPath = "Characters/Enemy/";
    private const string WeaponPath = "Weapons/";
    private const string EffectPath = "Effects/";
    private const string AudioPath = "Audios/";
    private const string SpritePath = "Sprites/";

    public GameObject LoadSoldier(string name)
    {
        return Instantiate(SoldierPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return Instantiate(EnemyrPath + name);
    }

    public GameObject LoadWeapon(string name)
    {
        return Instantiate(WeaponPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return Instantiate(EffectPath + name);
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load<AudioClip>(AudioPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        Debug.Log(SpritePath + name);
        return Resources.Load<Sprite>(SpritePath + name);
    }

    private GameObject Instantiate(string path)
    {
        GameObject go = LoadAsset(path) as GameObject;
        return Object.Instantiate(go);
    }

    private Object LoadAsset(string path)
    {
        Object obj = Resources.Load(path);
        if (obj == null) Debug.LogError("加载资源失败:" + path);
        return obj;
    }
}