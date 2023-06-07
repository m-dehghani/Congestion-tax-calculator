using System.Diagnostics;
using Domain.Entities.Abstract;
using Domain.Entities.Concrete;
using Domain.Services.Abstract;
using Domain.Services.Concrete;
using Domain.ValueTypes;
using Infrastructure.Data;

namespace Tests
{
    public class TaxTests
    {

        private readonly CityService cityService;
        public TaxTests()
        {
            cityService = new CityService("guthenberg");
        }

        [Fact]
        public void CarShouldReturn60ForOneDay()
        {
            var tax = cityService.CalcTax("Car", "123456", new List<DateTime>() { new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) });
            Trace.WriteLine($@"Sum is: {tax}");
            Assert.Equal(60, tax);
        }
        //[Fact]
        //public void ShouldReturn39()
        //{
        //    var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 07, 07, 59, 00) }, "car1", "");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(39, tax);
        //}

        //[Fact]
        //public void MaximumShouldReturn60()
        //{
        //    var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 23, 27), new DateTime(2013, 02, 07, 15, 27, 00) }, "car1", "string");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(60, tax);
        //}

        //[Fact]
        //public void ShouldReturn44()
        //{
        //    var car = new Car( new DateTime[] { new DateTime(2013, 02, 07, 15, 00, 00), new DateTime(2013, 02, 07, 17, 59, 00) }, "car1", "");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(44, tax);
        //}

        //[Fact]
        //public void ShouldReturn52()
        //{
        //    var car = new Car( new DateTime[] { new DateTime(2013, 02, 07, 8, 00, 00), new DateTime(2013, 02, 07, 16, 59, 00) }, "car1", "");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(52, tax);
        //}

        //[Fact]
        //public void ShouldReturn120()
        //{
        //    var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 06, 00, 00) }, "car1", "");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(120, tax);
        //}


        //[Fact]
        //public void ShouldReturn141()
        //{
        //    var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 07, 00, 00) }, "car1", "");
        //    var tax = guthenBergTaxCalculator.GetTax(car);
        //    Assert.Equal(141, tax);
        //}

    }

   
}