using System.Diagnostics;
using Domain.Entities;
using Domain.Services.Concrete;
using Domain.ValueTypes;
using Infrastructure.Data;

namespace Tests
{
    public class TaxTests
    {

        private readonly City guthenberg;
        private NewTaxCalculator guthenBergTaxCalculator;
        public TaxTests()
        {
            guthenberg = new City();
            guthenberg.MaxTotalfeePerDay = 60;
            guthenberg.TaxLineItems = new List<CityTaxLineItem>()
            {
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 0, 0),
                    End = new TimeOnly(06, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 30, 0),
                    End = new TimeOnly(06, 59, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(7, 0, 0),
                    End = new TimeOnly(7, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 0, 0),
                    End = new TimeOnly(8, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 30, 0),
                    End = new TimeOnly(14, 59, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 0, 0),
                    End = new TimeOnly(15, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 30, 0),
                    End = new TimeOnly(16, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(17, 0, 0),
                    End = new TimeOnly(17, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 0, 0),
                    End = new TimeOnly(18, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 30, 0),
                    End = new TimeOnly(05, 59, 0),
                    TaxAmount = 0
                },

            };
            guthenBergTaxCalculator = new(guthenberg);
        }
        
        [Fact]
        public void CarShouldReturn60ForOneDay()
        {
            Vehicle car1 = new Car(new DateTime[] { new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) },"Ford","New car");
            var tax = guthenBergTaxCalculator.GetTax(car1);
            Trace.WriteLine($@"Sum is: {tax}");
            Assert.Equal(60, tax);
        }
        [Fact]
        public void ShouldReturn39()
        {
            var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 07, 07, 59, 00) }, "car1", "");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(39, tax);
        }

        [Fact]
        public void MaximumShouldReturn60()
        {
            var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 23, 27), new DateTime(2013, 02, 07, 15, 27, 00) }, "car1", "string");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(60, tax);
        }

        [Fact]
        public void ShouldReturn44()
        {
            var car = new Car( new DateTime[] { new DateTime(2013, 02, 07, 15, 00, 00), new DateTime(2013, 02, 07, 17, 59, 00) }, "car1", "");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(44, tax);
        }

        [Fact]
        public void ShouldReturn52()
        {
            var car = new Car( new DateTime[] { new DateTime(2013, 02, 07, 8, 00, 00), new DateTime(2013, 02, 07, 16, 59, 00) }, "car1", "");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(52, tax);
        }

        [Fact]
        public void ShouldReturn120()
        {
            var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 06, 00, 00) }, "car1", "");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(120, tax);
        }


        [Fact]
        public void ShouldReturn141()
        {
            var car = new Car(new DateTime[] { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 07, 00, 00) }, "car1", "");
            var tax = guthenBergTaxCalculator.GetTax(car);
            Assert.Equal(141, tax);
        }

    }

   
}