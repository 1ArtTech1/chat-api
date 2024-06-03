using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.Models;

/// <summary>
/// The chat model.
/// </summary>
public class Chat : BaseEntity
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a messages.
    /// </summary>
    public ICollection<Message> Messages { get; set; }
}