using Chat.Application.Providers.Interfaces;

namespace Chat.Application.Providers;

/// <inheritdoc />
public class GroupManagerProvider : IGroupManagerProvider
{
    /// <inheritdoc />
    public IDictionary<string, int> GroupManager { get; set; } = new Dictionary<string, int>();
}