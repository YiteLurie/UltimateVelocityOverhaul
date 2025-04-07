public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Base Velocity Settings")]
    [Range(1f, 2f)]
    [DefaultValue(1.5f)]
    public float BaseProjectileVelocity { get; set; }

    [Header("Accessory Prefix Settings")]
    [DefaultValue(true)]
    public bool EnablePrefixes { get; set; }

    [Range(0.1f, 0.5f)]
    [DefaultValue(0.1f)]
    public float SwiftBonus { get; set; }

    [Range(0.1f, 0.5f)]
    [DefaultValue(0.15f)]
    public float BallisticBonus { get; set; }

    [Range(0.1f, 0.5f)]
    [DefaultValue(0.2f)]
    public float SonicBonus { get; set; }

    public static Config Instance => ModContent.GetInstance<Config>();
}