public class SoldierCaptive : Soldier
{
    private Enemy enemy;

    public SoldierCaptive(Enemy enemy)
    {
        this.enemy = enemy;

        //适配
        this.Attribute = enemy.Attribute;
        this.GameObject = enemy.GameObject;
        this.Weapon = enemy.Weapon;

    }

    protected override void PlayDeathSound() { }
}