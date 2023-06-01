using Congestion_tax_calculator_UI.Services;
using Domain.Entities;
using Domain.Services.Concrete;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Congestion_tax_calculator_UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
       
        private readonly ILogger<TaxController> _logger;
        private readonly TaxCalculator _taxCalculator;
        private readonly IRepository _repository;

        public TaxController(ILogger<TaxController> logger, TaxCalculator taxCalculator, IRepository repository)
        {
            _logger = logger;
            _taxCalculator = taxCalculator;
            _repository = repository;
        }

        [HttpPost(Name = "GetTax")]
        public IActionResult Get(string cityName, string vehicleType, DateTime[] dates)
        {
            try
            {
                var city = _repository.GetCity(cityName);
                TaxCalculator taxCalculator = new TaxCalculator(city);
                Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, dates);
                return Ok(taxCalculator.GetTax(vehicle));
            }
            catch 
            {
                return Problem();
            }
        }
    }
}