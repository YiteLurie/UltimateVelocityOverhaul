using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace UltimateVelocityOverhaul
{
    public class UltimateVelocityOverhaul : Mod
    {
        public override void Load()
        {
            // 1. Увеличиваем скорость всех снарядов по умолчанию
            On.Terraria.Projectile.NewProjectile += HookNewProjectile;
            
            // 2. Добавляем префиксы для аксессуаров
            On.Terraria.PrefixLoader.Load += AddVelocityPrefixes;
        }

        private int HookNewProjectile(On.Terraria.Projectile.orig_NewProjectile orig,
            float X, float Y, float SpeedX, float SpeedY, int Type, int Damage,
            float KnockBack, int Owner, float ai0, float ai1)
        {
            // Базовая скорость снарядов (можно менять в конфиге)
            float baseVelocityMultiplier = Config.Instance.BaseProjectileVelocity;
            
            SpeedX *= baseVelocityMultiplier;
            SpeedY *= baseVelocityMultiplier;
            
            return orig(X, Y, SpeedX, SpeedY, Type, Damage, KnockBack, Owner, ai0, ai1);
        }

        private void AddVelocityPrefixes(On.Terraria.PrefixLoader.orig_Load orig)
        {
            orig(); // Загружаем стандартные префиксы
            
            ModPrefix.AddPrefix("Swift", new VelocityPrefix("Swift", 0.1f, 1.2f));
            ModPrefix.AddPrefix("Ballistic", new VelocityPrefix("Ballistic", 0.15f, 1.35f));
            ModPrefix.AddPrefix("Sonic", new VelocityPrefix("Sonic", 0.2f, 1.5f));
        }

        public override void Unload()
        {
            On.Terraria.Projectile.NewProjectile -= HookNewProjectile;
            On.Terraria.PrefixLoader.Load -= AddVelocityPrefixes;
        }
    }
}