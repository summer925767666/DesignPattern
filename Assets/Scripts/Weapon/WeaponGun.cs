using UnityEngine;

public class WeaponGun:Weapon
{
    public WeaponGun(int atk, float atkRange, GameObject gameObject) : base(atk, atkRange, gameObject)
    {
    }

    protected override float GetLineWidth()
    {
        return 0.05f;
    }

    protected override string GetSoundName()
    {
        return "GunShoot";
    }

    protected override void SetEffectTimer()
    {
        EffectTimer = 0.2f;
    }
}

