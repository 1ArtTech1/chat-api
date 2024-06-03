namespace Chat.Api.Models.Settings;

/// <summary>
/// The swagger setting.
/// </summary>
public class SwaggerSetting
{
    /// <summary>
    ///     Gets or sets the title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///     Gets or sets the version.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///   Gets or sets the UrlFormat.
    /// </summary>
    public string UrlFormat { get; set; }

    /// <summary>
    ///   Gets or sets the AuthType.
    /// </summary>
    public string AuthType { get; set; }

    /// <summary>
    ///   Gets or sets the AuthScope.
    /// </summary>
    public string AuthScope { get; set; }

    /// <summary>
    ///    Gets or sets the AuthUrlFormat.
    /// </summary>
    public string AuthUrlFormat { get; set; }

    /// <summary>
    ///   Gets or sets the Scope.
    /// </summary>
    public string Scope { get; set; }
}