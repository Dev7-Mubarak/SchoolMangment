namespace SchoolMangment.Data.Entities
{
    public class DepartmetSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}
