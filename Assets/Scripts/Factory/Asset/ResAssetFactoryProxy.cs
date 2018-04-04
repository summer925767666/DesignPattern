using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResAssetFactoryProxy : IAssetFactory
{
    private readonly ResourcesAssetFactory resourcesAssetFactory = new ResourcesAssetFactory();
    private readonly Dictionary<string, GameObject> soldierDict = new Dictionary<string, GameObject>();

    public GameObject LoadSoldier(string name)
    {
        if (soldierDict.ContainsKey(name))
        {
            var go = soldierDict[name];
            return Object.Instantiate(go);
        }
        else
        {
            var go = resourcesAssetFactory.LoadAsset(ResourcesAssetFactory.SoldierPath + name) as GameObject;
            soldierDict.Add(name, go);
            return Object.Instantiate(go);
        }
    }

    public GameObject LoadEnemy(string name) { return resourcesAssetFactory.LoadEnemy(name); }

    public GameObject LoadWeapon(string name) { return resourcesAssetFactory.LoadWeapon(name);}

    public GameObject LoadEffect(string name) { return resourcesAssetFactory.LoadEffect(name);}

    public AudioClip LoadAudioClip(string name) { return resourcesAssetFactory.LoadAudioClip(name);}

    public Sprite LoadSprite(string name) { return resourcesAssetFactory.LoadSprite(name); }
}