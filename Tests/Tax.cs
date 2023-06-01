using Domain.Entities;
using Domain.Services.Concrete;
using Domain.ValueTypes;
using Infrastructure.Data;

namespace Tests
{
    public class TaxTests
    {
        
        
        [Fact]
        public void CarShouldReturn60ForOneDay()
        {
            IRepository repository = new FileRepository();
            City guthenberg = repository.GetCity("Guthenburg");
            
            TaxCalculator guthenBergTaxCalculator = new(guthenberg); 
            
            Vehicle car1 = new Car(new DateTime[] { new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) },"Ford","New car");
           
            var tax = guthenBergTaxCalculator.GetTax(car1);
            Assert.Equal(60, tax);
        }

        public class OldTax
        {
            [Fact]
            public void OneDayShouldReturn60()
            {
                CongestionTaxCalculator taxCalculator = new CongestionTaxCalculator();
                var car = new Car(new DateTime[0],"car1", "DEsc" );
                var tax = taxCalculator.GetTax(car, new DateTime[]{ new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) });
                Assert.Equal(60, tax);
            }
            
            [Fact]
            public void MaximumShouldReturn60()
            {
                CongestionTaxCalculator taxCalculator = new CongestionTaxCalculator();
                var car = new Car(new DateTime[0], "car1", "string");
                var tax = taxCalculator.GetTax(car, new DateTime[] { new DateTime(2013, 02, 07, 06, 23, 27), new DateTime(2013, 02, 07, 15, 27, 00) });
                Assert.Equal(60, tax);
            }

            [Fact]
            public void ShouldReturn39()
            {
                CongestionTaxCalculator taxCalculator = new CongestionTaxCalculator();
                var car = new Car(new DateTime[0], "car1", "");
                var tax = taxCalculator.GetTax(car, new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 07, 07, 59, 00) });
                Assert.Equal(39, tax);
            }

            [Fact]
            public void ShouldReturn44()
            {
                CongestionTaxCalculator taxCalculator = new CongestionTaxCalculator();
                var car = new Car(new DateTime[0], "car1", "");
                var tax = taxCalculator.GetTax(car, new DateTime[] { new DateTime(2013, 02, 07, 15, 00, 00), new DateTime(2013, 02, 07, 17, 59, 00) });
                Assert.Equal(44, tax);
            }

            [Fact]
            public void ShouldReturn52()
            {
                CongestionTaxCalculator taxCalculator = new CongestionTaxCalculator();
                var car = new Car(new DateTime[0], "car1", "");
                var tax = taxCalculator.GetTax(car, new DateTime[] { new DateTime(2013, 02, 07, 8, 00, 00), new DateTime(2013, 02, 07, 16, 59, 00) });
                Assert.Equal(52, tax);
            }

        }

    }

   
}