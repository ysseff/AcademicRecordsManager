using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }
    
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    [MaxLength(50, ErrorMessage = "Name must be at most 50 characters")]
    public string Name { get; set; }
    
    [Range(0, 100, ErrorMessage = "Degree must be between 0 and 100")]
    public int? Degree { get; set; }
    
    [Range(0, 100, ErrorMessage = "Min Degree must be between 0 and 100")]
    public int minDegree { get; set; }
    
    [ForeignKey("Department")]
    [DisplayName("Department")]
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    public List<Instructor>? Instructors { get; set; }
    public List<CrsResult>? CrsResults { get; set; }
}