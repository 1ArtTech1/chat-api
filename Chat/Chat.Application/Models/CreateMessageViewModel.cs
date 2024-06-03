namespace Chat.Application.Models;

public class CreateMessageViewModel
{
    public int ChatId { get; set; }
    
    public string Value { get; set; }
    
    public DateTime DateTime { get; set; }
}