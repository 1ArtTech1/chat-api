namespace Chat.Application.Providers.Interfaces;

/// <summary>
/// The group manager provider.
/// </summary>
public interface IGroupManagerProvider
{
    /// <summary>
    /// Gets or sets a group manager.
    /// </summary>
    IDictionary<string, int> GroupManager { get; set; }
}