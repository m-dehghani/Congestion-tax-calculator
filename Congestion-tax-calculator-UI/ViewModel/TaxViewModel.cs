using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Congestion_tax_calculator_UI.ViewModel
{
    public class TaxViewModel:IValidatableObject
    {
       
        [Required]
        public string CityName { get; set; }
        
        [Required]
        public string vehicleType { get; set; }
      
        public List<DateTime> Dates { get; set; }

        [Required]
        public string PlateNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(!Dates.Any())
            {
                yield return new ValidationResult("You should send at least two dates", new[] { nameof(Dates) });
            }
        }
    }
}
