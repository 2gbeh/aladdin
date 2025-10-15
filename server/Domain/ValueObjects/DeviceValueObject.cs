namespace server.Domain.ValueObjects;

public sealed record class DeviceValueObject
{
    public string DeviceId { get; }
    public string Platform { get; }           // e.g., iOS, Android, Web, Windows, macOS
    public string? OsVersion { get; }
    public string? AppVersion { get; }

    // For EF Core
    private DeviceValueObject()
    {
        DeviceId = Platform = string.Empty;
    }

    private DeviceValueObject(string deviceId, string platform, string? osVersion, string? appVersion)
    {
        DeviceId = deviceId;
        Platform = platform;
        OsVersion = osVersion;
        AppVersion = appVersion;
    }

    public static DeviceValueObject Create(string deviceId, string platform, string? osVersion = null, string? appVersion = null)
    {
        if (string.IsNullOrWhiteSpace(deviceId)) throw new ArgumentException("DeviceId is required", nameof(deviceId));
        if (string.IsNullOrWhiteSpace(platform)) throw new ArgumentException("Platform is required", nameof(platform));

        deviceId = deviceId.Trim();
        platform = platform.Trim();
        osVersion = string.IsNullOrWhiteSpace(osVersion) ? null : osVersion.Trim();
        appVersion = string.IsNullOrWhiteSpace(appVersion) ? null : appVersion.Trim();

        return new DeviceValueObject(deviceId, platform, osVersion, appVersion);
    }

    public override string ToString() => $"{Platform} {OsVersion} (DeviceId: {DeviceId}, App: {AppVersion})";
}