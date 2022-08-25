using System;
using System.ComponentModel.DataAnnotations;

namespace EmsModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
