namespace ElderlySystem.DAL.Model
{
    public class Sponsor : ApplicationUser
    {
        //public int Id { get; set; }
        public string? Note { get; set; }
        public ICollection<ElderlySponsor> ElderlySponsors { get; set; } = new List<ElderlySponsor>();

    }
}
