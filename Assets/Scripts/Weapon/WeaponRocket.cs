using UnityEngine;

public class WeaponRocket:Weapon
{
    public WeaponRocket(WeaponShareAttribute attribute, GameObject gameObject) : base(attribute, gameObject)
    {
    }

    protected override float GetLineWidth()
    {
        return 0.3f;
    }

    protected override string GetSoundName()
    {
        return "RocketShoot";
    }

    protected override void SetEffectTimer()
    {
        EffectTimer = 0.4f;
    }
}

