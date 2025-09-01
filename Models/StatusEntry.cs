namespace ParcelTrackingManager.Models
{
    public class StatusEntry
    {
        public int Id { get; set; }
        public required string Status { get; set; }
        public DateTime Timestamp { get; set; }

        // Foreign key relationship
        public int ParcelId { get; set; }
        public Parcel Parcel { get; set; }
    }
}

