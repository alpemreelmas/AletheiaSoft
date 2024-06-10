namespace AletheiaSoft.Domain.Entities;

public class Client : BaseAuditableEntity
{
    public string? FullName { get; set; }

    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Adress { get; set; }
    
    public string? ProfilePic { get; set; }

    public string? Note { get; set; }
    
}
