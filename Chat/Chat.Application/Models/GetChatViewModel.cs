namespace Chat.Application.Models;

/// <summary>
/// The get chat view model.
/// </summary>
public class GetChatViewModel
{
    /// <summary>
    /// Gets or sets a identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a messages.
    /// </summary>
    public IEnumerable<GetMessageViewModel> Messages { get; set; }
}