 public class CharacterDirector
{
    public static Character Construct(AbstractCharacterBuilder builder)
    {
        builder.BuildAttribute();
        builder.BuildGameObject();
        builder.BuildWeapon();

        return builder.GetCharacter();
    }
}

