public class ParcelDto
{
    public required string TrackingNumber { get; set; }
    public required string SenderName { get; set; }
    public required string SenderPhone { get; set; }
    public required string SenderAddress { get; set; }
    public required string RecipientName { get; set; }
    public required string RecipientPhone { get; set; }
    public required string RecipientAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}

