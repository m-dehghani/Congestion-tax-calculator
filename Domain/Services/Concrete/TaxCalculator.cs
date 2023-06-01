using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueTypes;

namespace Domain.Services.Concrete
{
    public class TaxCalculator
    {
        private RuleService rS;

        public TaxCalculator(RuleService rS)
        {
            this.rS = rS;
        }

        public Tax calcTax(Vehicle car1)
        {
            throw new NotImplementedException();
        }
    }
}
