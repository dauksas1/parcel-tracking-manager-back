namespace ParcelTrackingManager.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public required string TrackingNumber { get; set; }

        public required Person Sender { get; set; }
        public required Person Recipient { get; set; }

        public required string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Timestamp for last status update
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Status history tracking
        public List<StatusEntry> StatusHistory { get; set; } = new();
    }
}



