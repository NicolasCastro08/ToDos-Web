using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoPlataform.Models;

[Table("todos")]

public class ToDo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id {get; set; }

    [Required]
    
    public string UserId { get; set; }


    public AppUser User { get; set; }

    [StringLength(100)]

    public string Title { get; set; }

    






}