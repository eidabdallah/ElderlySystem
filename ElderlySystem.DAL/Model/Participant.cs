namespace ElderlySystem.DAL.Model
{
    public class Participant
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }

        //multi value btw Participant and Activity
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
