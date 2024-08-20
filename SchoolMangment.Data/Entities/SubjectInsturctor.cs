namespace SchoolMangment.Data.Entities
{
    public class SubjectInsturctor
    {
        public int Id { get; set; }
        public int InsturctorId { get; set; }
        public Instructor Instructor { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
