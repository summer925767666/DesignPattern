public class SoldierCaptain:Soldier
{
    protected override void PlayDeathSound()
    {
        base.PlaySound("CaptainDeath");
    }

    protected override void PlayDeathEffect()
    {
        base.PlayEffect("death");
    }

}

