using System.ComponentModel.DataAnnotations;
using MenuItens.Validations;

namespace MenuItens.Models
{
    public class PrdActive //Model for Status of a Menu Item
    {

        [Key]
        public int PrdId { get; set; }

        //Validations for the status change
        [Required]
        [StatusValidation (ErrorMessage = "The status must to be 0 or 1")]
        public int PrdStatus { get; set; }

        //Navigation Navigation Property
        public virtual Product? Product { get; set; } 
    }
 
}
