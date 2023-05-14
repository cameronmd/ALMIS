using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALMIS.Model
{
    public class InvestmentProductModel
    {
        public string Name { get; set; }
        public double InterestRate { get; set; }
        public CompoundingFrequency Compounding { get; set; }
        public int MonthsFixed { get; set; }
    }

    public enum CompoundingFrequency
    {
        Monthly,
        Annually
    }
}
