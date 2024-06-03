namespace Chat.Application.Models;

public class GetChatViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<GetMessageViewModel> Messages { get; set; }
}