using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class Instructor
{
    [Key]
    public int InstructorId { get; set; }
    
    [Required]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    [MaxLength(50, ErrorMessage = "Name must be at most 50 characters")]
    public string Name { get; set; }
    public string? Image { get; set; }
    
    [Range(1000, 1000000, ErrorMessage = "Salary must be between 1000 and 1000000")]
    public int? Salary { get; set; }
    
    [MinLength(3, ErrorMessage = "Address must be at least 3 characters")]
    [MaxLength(150, ErrorMessage = "Address must be at most 50 characters")]
    public string? Address { get; set; }
    
    [ForeignKey("Department")]
    [DisplayName("Department")]
    public int? DepartmentId { get; set; }
    
    public Department? Department { get; set; }
    
    [ForeignKey("Course")]
    public int? CourseId { get; set; }
    
    public Course? Course { get; set; }
    
}