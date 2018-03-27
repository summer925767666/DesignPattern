public static class FactoryManger
{
    private static IAssetFactory assetFactory;
    private static CharacterFactory characterFactory;
    private static SoldierFactory soldierFactory;
    private static EnemyFactory enemyFactory;
    private static WeaponFactory weaponFactory;
    private static AttributeFactory attributeFactory;

    public static IAssetFactory AssetFactory
    {
        get { return assetFactory ?? (assetFactory = new ResourcesAssetFactory()); }
    }

    public static CharacterFactory CharacterFactory
    {
        get { return characterFactory ?? (characterFactory = new CharacterFactory()); }
    }

    public static SoldierFactory SoldierFactory
    {
        get { return soldierFactory ?? (soldierFactory = new SoldierFactory()); }
    }

    public static EnemyFactory EnemyFactory
    {
        get { return enemyFactory ?? (enemyFactory = new EnemyFactory()); }
    }

    public static WeaponFactory WeaponFactory
    {
        get { return weaponFactory ?? (weaponFactory = new WeaponFactory()); }
    }

    public static AttributeFactory AttributeFactory
    {
        get { return attributeFactory ?? (attributeFactory = new AttributeFactory()); }
    }
}

