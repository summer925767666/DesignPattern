public static class FactoryManger
{
    private static IAssetFactory assetFactory;
    private static SoldierFactory soldierFactory;
    private static EnemyFactory enemyFactory;
    private static WeaponFactory weaponFactory;

    public static IAssetFactory AssetFactory
    {
        get { return assetFactory ?? (assetFactory = new ResourcesAssetFactory()); }
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

}

