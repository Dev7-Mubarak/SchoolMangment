using System.ComponentModel.DataAnnotations;

namespace SchoolMangment.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string NameEn { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<StudentSubject> StudentSubject { get; set; } = new HashSet<StudentSubject>();
    }
}
