using System;

namespace HomeCare.Worker.Models;

public class ContractMessage
{
    public Guid Id { get; set; }
    public UserMessage Client { get; set; }
    public UserMessage Supplier { get; set; }
    public string JobDescription { get; set; }
    public DateTime ExecutionDate { get; set; }
}
