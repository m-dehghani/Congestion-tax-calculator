using Congestion_tax_calculator_UI.ViewModel;
using Domain.Entities;
using Domain.Services.Concrete;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Congestion_tax_calculator_UI.Services
{
    public class TaxService
    {
        private readonly IRepository _repository;

        public TaxService(IRepository repository)
        {
            _repository = repository;
        }
        public int  CalcTax(TaxViewModel viewModel)
        {
            var city = _repository.GetCity(viewModel.CityName);
            TaxCalculator taxCalculator = new TaxCalculator(city);
            Vehicle vehicle = VehicleFactory.CreateVehicle(viewModel.vehicleType, viewModel.Dates);
            return taxCalculator.GetTax(vehicle);
        }

    }
}
