using System.ComponentModel.DataAnnotations;
namespace Carss.Models
{
    public class Calendar
    {
        [Key]
        public Guid RentalId { get; set; }  

        [Required]  
        [MaxLength(50)]  
        public string VehicleName { get; set; }  

        [Required]  
        [MaxLength(50)] 
        public string CustomerName { get; set; }  

        [Required]  
        public DateTime RentalDate { get; set; }  

        [Required] 
        public DateTime ReturnDate { get; set; } 

        [Required] 
        public bool IsReturned { get; set; }  

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
