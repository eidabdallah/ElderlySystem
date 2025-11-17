namespace ElderlySystem.DAL.Model
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public DateTime DonationDate { get; set; }
        public decimal? MonetaryAmount { get; set; }
        public string? Currency { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }


        // 1 - m relation btw Donation and good
        public ICollection<Good> Goods { get; set; } = new List<Good>();

    }
}
