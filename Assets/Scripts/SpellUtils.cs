class SpellUtils
{
    public static double manaContentToForceRatio = 50;
    public static double ManaContentToForce(double manaPower)
    {
        return manaPower * manaContentToForceRatio;
    }
}