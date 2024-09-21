using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRentalOfPremises.Infrastructure
{
    public interface OutleetModelParserInterface
    {
        OutletModel Parse(string content);
        string ConvertTo(OutletModel model);
    }
}
