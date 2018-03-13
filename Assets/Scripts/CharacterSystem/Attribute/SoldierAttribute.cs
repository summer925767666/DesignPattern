public class SoldierAttribute:CharacterAttribute
{
    public SoldierAttribute(string name, int maxHP, float moveSpeed, string iconSprite, string prefabName,int lv) : 
        base(name, maxHP, moveSpeed, iconSprite, prefabName,lv,  new SoldierAttributeStrategy())
    {
    }
}

