using UnityEngine;

public class EnemyElf:Enemy
{

    protected override void PlayDmgEffect()
    {
        base.PlayEffect("damage");
    }
}

