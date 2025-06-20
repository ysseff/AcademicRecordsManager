using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }
    
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    [MaxLength(50, ErrorMessage = "Name must be at most 50 characters")]
    public string Name { get; set; }
    public int Manager { get; set; }
    
    public List<Student>? Students { get; set; }
    public List<Instructor>? Instructors { get; set; }
    public List<Course>? Courses { get; set; }
}