namespace RestTomas.Data.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
    }
}