using ApplicationRentalOfPremises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace ApplicationRentalOfPremises.Storeges.Reps
{
    public class outleetmodel_fasade_rep_json:FileStoregeAdapter
    {
        public outleetmodel_fasade_rep_json(string file_name):base(file_name,new Parsers.JsonOutleetModelParser())
        {

        }
        
    }
}
