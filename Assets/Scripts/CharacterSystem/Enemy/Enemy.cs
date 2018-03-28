public abstract class Enemy :Character
{
    protected EnemyFSMSystem Fsm;

    protected Enemy() 
    {
        MakeFsm();
    }

    public void UpdateFSM(EnemyStateData data)
    {
//        if (base.IsDead) return;

        Fsm.Reason(data);
        Fsm.Act(data);
    }

    private void MakeFsm()
    {
        Fsm = new EnemyFSMSystem();

        EnemyChaseState chase = new EnemyChaseState(Fsm, this);
        chase.AddTransition(EnemyTransition.CanAttack, EnemyStateID.Attack);

        EnemyAttackState attack = new EnemyAttackState(Fsm, this);
        attack.AddTransition(EnemyTransition.LostSoldier, EnemyStateID.Chase);

        Fsm.AddState(chase, attack);
    }

    protected sealed override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);

//        PlayDmgEffect();

        //判断是否死亡
        if (base._Attribute.CurrentHp > 0) return;

        base.Die();
        GameFacade.Instance.CharacterSystem.RemoveEnemy(this);
    }

    protected abstract void PlayDmgEffect();//没有必要使用多态，模版方法，只需要一个参数就可以，这里是为了学习而学习
}
