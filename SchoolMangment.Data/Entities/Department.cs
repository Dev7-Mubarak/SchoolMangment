using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolMangment.Data.Entities
{
    public partial class Department
    {

        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        public int Id { get; set; }
        public int? InsManagerId { get; set; }
        [MaxLength(300)]
        public string? DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }

        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student>? Students { get; set; }

        [InverseProperty(nameof(DepartmetSubject.Department))]
        public virtual ICollection<DepartmetSubject>? DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.Department))]
        //Instructors teaching in this department
        public virtual ICollection<Instructor>? Instructors { get; set; }

        [ForeignKey("InsManagerId")]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        // Manager
        public virtual Instructor? Instructor { get; set; }
    }
}
