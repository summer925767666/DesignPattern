using System;

public abstract class Soldier : Character
{


    protected SoldierFSMSystem Fsm;

    protected Soldier()
    {
        MakeFsm();
    }

    public void UpdateFSM(SoldierStateData data)
    {
        Fsm.Reason(data);
        Fsm.Act(data);
    }

    private void MakeFsm()
    {
        Fsm = new SoldierFSMSystem();

        SoldierIdleState idle = new SoldierIdleState(Fsm, this);
        idle.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        SoldierChaseState chase = new SoldierChaseState(Fsm, this);
        chase.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        chase.AddTransition(SoldierTransition.CanAttack, SoldierStateID.Attack);

        SoldierAttackState attack = new SoldierAttackState(Fsm, this);
        attack.AddTransition(SoldierTransition.NoEnemy, SoldierStateID.Idle);
        attack.AddTransition(SoldierTransition.SeeEnemy, SoldierStateID.Chase);

        Fsm.AddState(idle, chase, attack);
    }

    protected sealed override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);

        //判断是否死亡
        if (base._Attribute.CurrentHp <= 0)
        {
            PlayDeathEffect();
            PlayDeathSound();

            base.Die();
        }
    }

    protected abstract void PlayDeathSound();//没有必要使用多态，模版方法，只需要一个参数就可以，这里是为了学习而学习
    protected abstract void PlayDeathEffect();
}