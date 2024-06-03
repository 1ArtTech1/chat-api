using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Domain.Models;

/// <summary>
/// The message model.
/// </summary>
public class Message : BaseEntity
{
    /// <summary>
    /// Gets or sets a value.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Value { get; set; }

    /// <summary>
    /// Gets or sets a date time.
    /// </summary>
    [Required]
    public DateTime DateTime { get; set; }
    
    /// <summary>
    /// Gets or sets a chat ID.
    /// </summary>
    [Required]
    public int ChatId { get; set; }
    
    /// <summary>
    /// Gets or sets a chat.
    /// </summary>
    [ForeignKey(nameof(ChatId))]
    public Chat Chat { get; set; }
}