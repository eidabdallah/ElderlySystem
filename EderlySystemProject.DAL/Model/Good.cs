namespace ElderlySystem.DAL.Model
{
    public class Good
    {
        public int Id { get; set; }
        public string NameGood { get; set; }
        public int? Quantity { get; set; }

        // multi value btw Donation and good
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
    }
}
