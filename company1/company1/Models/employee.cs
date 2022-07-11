using System.ComponentModel.DataAnnotations;



namespace company1.Models
{
    public class employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public DateTime Joiningdate { get; set; }
    }
}
