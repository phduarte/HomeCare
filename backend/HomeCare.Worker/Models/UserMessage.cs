using System;

namespace HomeCare.Worker.Models;

public class UserMessage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
