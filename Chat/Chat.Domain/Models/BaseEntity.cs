using System.ComponentModel.DataAnnotations;

namespace Chat.Domain.Models;

/// <summary>
/// The base entity model.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    [Key]
    public int Id { get; set; }
}