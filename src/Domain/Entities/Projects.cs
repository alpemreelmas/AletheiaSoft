namespace AletheiaSoft.Domain.Entities;

public class Project : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? Budget { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? LastDate { get; set; }
    public int? YearlyCost { get; set; }
    public string? Currency { get; set; }
    public DateTime? YearlyPaymentDate { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
}
