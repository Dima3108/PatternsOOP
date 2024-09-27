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
        OutleetModel Parse(string content);
        OutleetModel[]ParseArray(string content);
        string ConvertTo(OutleetModel model);
        string ConvertTo(OutleetModel[] models);
    }
}
