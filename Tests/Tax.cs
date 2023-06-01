using Domain.Entities;
using Domain.Services.Concrete;
using Domain.ValueTypes;
using Infrastructure.Data;

namespace Tests
{
    public class TaxTests
    {
        private Repository _repo;
        public TaxTests(Repository repo)
        {
            _repo =  repo ?? throw new ArgumentNullException(nameof(repo));
        }
        [Fact]
        public void CarShouldReturn60ForOneDay()
        {
            City guthenberg = _repo.GetCity("Guthenburg");
            RuleService RS = new RuleService(guthenberg);
            TaxCalculator guthenBergTaxCalculator = new TaxCalculator(RS); 
            
            Vehicle car1 = new Car("Ford","New car");
            Car.Enter(guthenberg, new DateTime(2013, 01, 14, 21, 00, 00));
            Car.Leave(guthenberg, new DateTime(2013, 01, 15, 21, 00, 00));

            Tax tax = guthenBergTaxCalculator.calcTax(car1);
            Assert.Equal(60, tax.Amount);
        }
    }

   
}