using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} must be from {1} and {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BasicSalary { get; set; }
        
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() 
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double basicSalary, Department department) 
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BasicSalary = basicSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }

        public void Remove(SalesRecord sr) 
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) 
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
