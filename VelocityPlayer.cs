public class VelocityPlayer : ModPlayer
{
    public float AccessoryVelocityBonus = 0f;

    public override void ResetEffects() => AccessoryVelocityBonus = 0f;

    public override void UpdateEquips()
    {
        // Применяем бонусы от аксессуаров
        foreach (Item item in Player.armor)
        {
            if (item.prefix == ModContent.PrefixType("Swift"))
                AccessoryVelocityBonus += 0.1f;
            else if (item.prefix == ModContent.PrefixType("Ballistic"))
                AccessoryVelocityBonus += 0.15f;
            else if (item.prefix == ModContent.PrefixType("Sonic"))
                AccessoryVelocityBonus += 0.2f;
        }
    }

    public override void ModifyShootStats(Item item, ref Vector2 position,
        ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        // Умножаем скорость снаряда на оба эффекта:
        // 1. Базовый множитель из конфига
        // 2. Бонус от аксессуаров
        velocity *= (1f + AccessoryVelocityBonus);
    }
}