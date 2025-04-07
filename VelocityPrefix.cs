public class VelocityPrefix : ModPrefix
{
    public string PrefixName { get; }
    public float VelocityBonus { get; }
    public float ValueMultiplier { get; }

    public VelocityPrefix(string name, float bonus, float valueMult)
    {
        PrefixName = name;
        VelocityBonus = bonus;
        ValueMultiplier = valueMult;
    }

    public override float RollChance(Item item) => item.accessory ? 3.5f : 0f;
    public override bool CanRoll(Item item) => item.accessory;
    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void SetStats(ref float damageMult, ref float knockbackMult,
        ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult,
        ref float manaMult, ref int critBonus)
    {
        shootSpeedMult *= (1f + VelocityBonus);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= ValueMultiplier;
    }
}