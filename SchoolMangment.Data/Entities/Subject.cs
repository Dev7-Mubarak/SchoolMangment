using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangment.Data.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public string SubjectNameEn { get; set; }
        public int Period { get; set; }
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; } = new HashSet<DepartmetSubject>();
    }

}
