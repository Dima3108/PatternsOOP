using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Infrastructure
{
    public interface OutleetModelInterface
    {
        int GetStorey();
        int GetInventoryNumber();
        decimal GetRentalCostPerDay();
    }
}
