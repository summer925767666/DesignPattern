using UnityEngine;
using UnityEditor;

public abstract class CharacterVisitor
{
    public abstract void VisitSoldier(Soldier soldier);
    public abstract void VisitEnemy(Enemy enemy);
}