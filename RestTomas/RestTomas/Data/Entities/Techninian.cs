namespace RestTomas.Data.Entities
{
    public class Techninian
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public int CenterId { get; set; }
        public Center Center { get; set; }
    }
}
