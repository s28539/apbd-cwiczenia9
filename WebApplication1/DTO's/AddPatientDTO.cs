﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO_s;

public class AddPatientDTO
{
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)] 
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
}