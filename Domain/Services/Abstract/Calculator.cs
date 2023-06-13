using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Abstract
{
    public interface ICalculator
    {
        public decimal GetTax(Vehicle vehicle);
    }

}
