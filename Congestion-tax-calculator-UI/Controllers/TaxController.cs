using Congestion_tax_calculator_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Congestion_tax_calculator_UI.ViewModel;

namespace Congestion_tax_calculator_UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly TaxService _taxService;

        public TaxController(TaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost(Name = "GetTax")]
        public IActionResult Get(TaxViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);
          
            try
            {
                return Ok(_taxService.CalcTax(viewModel));
            }
            catch 
            {
                return Problem();
            }
        }

       
    }
}