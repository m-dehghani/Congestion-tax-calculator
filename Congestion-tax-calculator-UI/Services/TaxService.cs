using Congestion_tax_calculator_UI.ViewModel;
using Domain.Entities.Abstract;
using Domain.Services.Abstract;
using Domain.Services.Concrete;
using Infrastructure.Data.Abstract;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Congestion_tax_calculator_UI.Services
{
    public class TaxService
    {
        private readonly CityRepository _repository;
        private readonly CityService _cityService;

        public TaxService(CityRepository repository, CityService cityService)
        {
            _repository = repository;
            _cityService = cityService;
        }
        public decimal  CalcTax(TaxViewModel viewModel)
        {
            return _cityService.CalcTax(viewModel.vehicleType,viewModel.PlateNo, viewModel.Dates);
           
        }

    }
}
