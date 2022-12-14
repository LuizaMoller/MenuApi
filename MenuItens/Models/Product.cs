using MenuItens.Validations;
using System.ComponentModel.DataAnnotations;


namespace MenuItens.Models
{
    public class Product //Model for Menu Item
    {
        [Key]
        public int Id { get; set; }

        public string PrdName { get; set; }

        //Validations for the product types and the types of its components
        [Required]
        [TypeValidation(ErrorMessage = "The type must be 1, 2 or 3")]
        [ComponentTypeValidation(ErrorMessage = "Invalid Component Type for Product Type")]
        public int PrdType { get; set; }

        //Navigation Navigation Properties
        public virtual PrdActive? PrdActive { get; set; }

        public virtual List<PrdComponents> Components { get; set; }

    }

}
