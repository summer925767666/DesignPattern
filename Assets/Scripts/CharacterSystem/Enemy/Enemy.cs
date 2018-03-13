public abstract class Enemy :Character
{
    protected EnemyFSMSystem Fsm;

    protected Enemy() 
    {
        MakeFsm();
    }

    public void UpdateFSM(EnemyStateData data)
    {
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

        //todo,播放特效
        PlayDmgEffect();

        //判断是否死亡
        if (base._Attribute.CurrentHp <= 0)
        {
            base.Die();
        }
    }

    protected abstract void PlayDmgEffect();
}
