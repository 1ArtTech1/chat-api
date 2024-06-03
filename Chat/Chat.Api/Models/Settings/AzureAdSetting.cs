namespace Chat.Api.Models.Settings;

/// <summary>
/// The Azure AD setting.
/// </summary>
public class AzureAdSetting
{
    /// <summary>
    /// Gets or sets a Tenant Id.
    /// </summary>
    public string TenantId { get; set; }

    /// <summary>
    /// Gets or sets a Instance.
    /// </summary>
    public string Instance { get; set; }

    /// <summary>
    /// Gets or sets a Client ID.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary>
    /// Gets or sets a Audience.
    /// </summary>
    public string Audience { get; set; }
}