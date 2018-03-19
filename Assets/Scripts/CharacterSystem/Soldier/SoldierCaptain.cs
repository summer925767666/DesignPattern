public class SoldierCaptain:Soldier
{
    protected override void PlayDeathSound()
    {
        base.PlaySound("death");
    }

    protected override void PlayDeathEffect()
    {
        base.PlayEffect("death");
    }

}

