using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class CrsResult
{
    public int CrsResultId { get; set; }
    public int? Degree { get; set; }
    
    [ForeignKey("Student")]
    [DisplayName("Student")]
    public int? StudentId { get; set; }
    public Student? Student { get; set; }
    
    [ForeignKey("Course")]
    [DisplayName("Course")]
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
    
}