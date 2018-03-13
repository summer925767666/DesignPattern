public class CharacterDirector
{
    public static Character Construct(CharacterBuilder builder)
    {
        builder.BuildAttribute();
        builder.BuildGameObject();
        builder.BuildWeapon();

        return builder.GetCharacter();
    }
}

