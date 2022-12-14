using MenuItens.Models;
using System.ComponentModel.DataAnnotations;


namespace MenuItens.Validations //Custom validations with Data Annotations
{
    //Validation for the Product Types. That can only receive :  [1] PRODUCT,  [2] CHOICE or [3] VALUE MEAL .
    public class TypeValidation : ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToInt32(value) == 1 || Convert.ToInt32(value) == 2 || Convert.ToInt32(value) == 3)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    //Validation for the Product Components. Which implements the component rules:
    //• A CHOICE is a Menu Item that has PRODUCT's as components
    //•	A VALUE MEAL is a Menu Item that has PRODUCT's and CHOICE's as components
    public class ComponentTypeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Product)validationContext.ObjectInstance;

            if (model.Components == null)
            {
                return ValidationResult.Success;
            }
            else if (model.PrdType == 2 && model.Components.All(x => x.PrdId == model.Id && x.ProductChild.PrdType == 1))
            {
                return ValidationResult.Success;
            }
            else if (model.PrdType == 3 && model.Components.All(x => x.PrdId == model.Id && x.ProductChild.PrdType == 1 || x.ProductChild.PrdType == 2))
            {
                return ValidationResult.Success;
            }
            else if (model.PrdType == 1)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }

    //Validation for the Product Status. That can only receive :  [1] ACTIVE or [0] INACTIVE.
    public class StatusValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToInt32(value) == 0 || Convert.ToInt32(value) == 1)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
