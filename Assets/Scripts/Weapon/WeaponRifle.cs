using UnityEngine;

public class WeaponRifle:Weapon
{
    public WeaponRifle(WeaponShareAttribute attribute, GameObject gameObject) : base(attribute, gameObject)
    {
    }

    protected override float GetLineWidth()
    {
        return 0.1f;
    }

    protected override string GetSoundName()
    {
        return "RifleShoot";
    }

    protected override void SetEffectTimer()
    {
        EffectTimer = 0.3f;
    }
}

