using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Concrete
{
    public class RuleService
    {
        private City City;

        public RuleService(City guthenberg)
        {
            this.City = guthenberg;
        }
    }
}
