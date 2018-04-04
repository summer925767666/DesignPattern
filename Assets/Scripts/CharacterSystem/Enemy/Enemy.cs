public abstract class Enemy : Character
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
        base.Attribute.TakeDamage(dmg);

        //判断是否死亡
        if (base.Attribute.CurrentHp > 0) return;

        base.Die();
        GameFacade.Instance.CharacterSystem.RemoveEnemy(this);
        GameFacade.Instance.EventSystem.Notify(typeof(EnemyKilledSubject));
    }

//    protected abstract void PlayDmgEffect(); //没有必要使用多态，模版方法，只需要一个参数就可以，这里是为了学习而学习

    public override void RunVisitor(CharacterVisitor visitor)
    {
        visitor.VisitEnemy(this);
    }
}