public class SoldierSergeant:Soldier
{

    protected override void PlayDeathSound()
    {
        base.PlaySound("SergeantDeath");
    }

//    protected override void PlayDeathEffect()
//    {
//    }
}

