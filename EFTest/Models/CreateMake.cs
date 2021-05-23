using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Models
{
    public class CreateMake
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Abrv { get; set; }
    }
}
